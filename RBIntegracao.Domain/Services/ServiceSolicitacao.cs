using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao;
using RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Services
{
    public class ServiceSolicitacao : Notifiable, IServiceSolicitacao
    {
        private readonly IRepositorySolicitacao _repositorySolicitacao;
        private readonly IRepositoryGrupoFornecedor _repositoryGrupoFornecedor;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ServiceSolicitacao(IRepositorySolicitacao repositorySolicitacao, IRepositoryGrupoFornecedor repositoryGrupoFornecedor, IRepositoryUsuario repositoryUsuario)
        {
            _repositorySolicitacao = repositorySolicitacao;
            _repositoryGrupoFornecedor = repositoryGrupoFornecedor;
            _repositoryUsuario = repositoryUsuario;
        }

        public AdicionarSolicitacaoResponse AdicionarSolicitacao(AdicionarSolicitacaoRequest request, Guid idUsuario)
        {

            if (request == null)
            {
                AddNotification("Resquest", "Invalido");
                return null;
            }


            if (request.CnpjFornecedor == null)
            {
                AddNotification("Fornecedor", "Invalido");
                return null;
            }

            var cliente = _repositoryUsuario.ObterPorId(idUsuario);

            if (cliente.ClienteOuFornecedor != 0)
            {
                AddNotification("Usuario", "O mesmo tem que esta cadastrado como cliente, para realizar uma solicitação");
                return null;
            }

            if (cliente.ClienteOuFornecedor == 0)
            {
                AddNotification("CnpjFornecedor", "O mesmo tem que esta cadastrado como fornecedor");
                return null;
            }

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
                return null;
            }


            // AdicionarUsuarioNotification adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario);

            // await _mediator.Publish(adicionarUsuarioNotification);

            return new AdicionarSolicitacaoResponse(solicitacao.Id);

        }

        public ListarSolicitacaoResponse ListarSolicitacaoFornecedor(ListarSolicitacaoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
