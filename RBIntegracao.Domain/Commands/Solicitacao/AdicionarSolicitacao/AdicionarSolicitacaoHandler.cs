using MediatR;
using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao
{
    public class AdicionarSolicitacaoHandler : Notifiable, IRequestHandler<AdicionarSolicitacaoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositorySolicitacao _repositorySolicitacao;
        private readonly IRepositoryGrupoFornecedor _repositoryGrupoFornecedor;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarSolicitacaoHandler(IMediator mediator, IRepositorySolicitacao repositorySolicitacao, IRepositoryGrupoFornecedor repositoryGrupoFornecedor, IRepositoryUsuario repositoryFornecedor)
        {
            _mediator = mediator;
            _repositorySolicitacao = repositorySolicitacao;
            _repositoryGrupoFornecedor = repositoryGrupoFornecedor;
            _repositoryUsuario = repositoryFornecedor;
        }

        public async Task<Response> Handle(AdicionarSolicitacaoRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                AddNotification("Resquest", "Invalido");
                return new Response(this);
            }

            if (request.CnpjFornecedor == null)
            {
                AddNotification("Fornecedor", "Invalido");
                return new Response(this);
            }
            
            var cliente = _repositoryUsuario.ObterPorId(request.IdUsuario.Value);
            var solicitacao = new Entities.Solicitacao(cliente, request.CodigoProduto, request.Descricao,
                                                       request.PrevisaoTerminoEstoque, request.QuantidadeSolicitada,
                                                       request.Observacao);

            AddNotifications(solicitacao);

            solicitacao = _repositorySolicitacao.Adicionar(solicitacao);

            var grupoFornecedor = new List<GrupoFornecedor>();

            foreach (var item in request.CnpjFornecedor)
            {
                var fornecedor = _repositoryUsuario.ObterPor(x => x.CnpjCpf.Equals(item));

                if (fornecedor != null)
                  grupoFornecedor.Add(new Entities.GrupoFornecedor(fornecedor, solicitacao));        
            }

            AddNotifications(grupoFornecedor);

            if (grupoFornecedor.Count > 0)
            {
                _repositoryGrupoFornecedor.AdicionarLista(grupoFornecedor);
            }
            else
            {
                AddNotification("Fornecedor", "É necessário informar Fornecedor já cadastrado");
                return new Response(this);
            }
           

            

            var response = new Response(this, solicitacao);

            // AdicionarUsuarioNotification adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario);

            // await _mediator.Publish(adicionarUsuarioNotification);

            return await Task.FromResult(response);
        }

        
    }
}
