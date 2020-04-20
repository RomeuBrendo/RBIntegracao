using MediatR;
using RBIntegracao.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao
{
    public class ListarSolicitacaoHandler : Notifiable, IRequestHandler<ListarSolicitacaoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositorySolicitacao _repositorySolicitacao;
        private readonly IRepositoryGrupoFornecedor _repositoryGrupoFornecedor;

        public ListarSolicitacaoHandler(IMediator mediator, IRepositorySolicitacao repositorySolicitacao, IRepositoryGrupoFornecedor repositoryGrupoFornecedor)
        {
            _mediator = mediator;
            _repositorySolicitacao = repositorySolicitacao;
            _repositoryGrupoFornecedor = repositoryGrupoFornecedor;
        }

        public async Task<Response> Handle(ListarSolicitacaoRequest request, CancellationToken cancellationToken)
        {
            //Valida se o objeto request esta nulo
            if (request == null)
            {
                AddNotification("Request", "Invalido");
                return new Response(this);
            }

            var SolicitacaoCollection = _repositorySolicitacao.ListarSolicitacaoFornecedor(request.Id);


            //Cria objeto de resposta
            var response = new Response(this, SolicitacaoCollection);

            ////Retorna o resultado
            return await Task.FromResult(response);
        }
    }
}
