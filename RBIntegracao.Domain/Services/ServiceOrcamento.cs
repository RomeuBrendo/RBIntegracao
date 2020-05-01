using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBIntegracao.Domain.Services
{
    public class ServiceOrcamento : Notifiable, IServiceOrcamento
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryOrcamento _repositoryOrcamento;

        public ServiceOrcamento(IRepositoryUsuario repositoryUsuario, IRepositoryOrcamento repositoryOrcamento)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryOrcamento = repositoryOrcamento;
        }

        public AdicionarOrcamentoResponse AdicionarOrcamento(AdicionarOrcamentoRequest request, Guid idUsuario)
        {
            if (request == null)
            {
                AddNotification("Resquest", "Invalido");
                return null;
            }
            var fornecedor = _repositoryUsuario.ObterPorId(idUsuario);

            if (_repositoryOrcamento.Existe(x => x.IdExterno == request.IdExterno &&
                                                 x.FornecedorSolicitante.Id == idUsuario))
            {
                AddNotification("Id Externo", "Já existe um Orçamento desta empresa com este Id");
               
            }

            List<Solicitacao> solicitacoes = new List<Solicitacao>();

            foreach (var item in request.IdExternoSolicitacao)
            {
                var solicitacao = _repositoryOrcamento.VerificaIdExternoSolicitacao(idUsuario, item);

                if(solicitacao != null)
                    solicitacoes.Add(solicitacao);
                else
                {
                    AddNotification("Id Externo Solicitação", "Inválido, confirme se o mesmo existe. Número: "+item);
                    
                }

            }

           
           var itens = PopulaItemOrcamento(request.Itens);

           var orcamento = new Entities.Orcamento(fornecedor, request.IdExterno, request.ValorTotal, request.Frete, request.Seguro, request.FormaPagamento,
                                                   request.Parcelas, itens);


            AddNotifications(orcamento);

            if (IsInvalid()) return null;


            orcamento = _repositoryOrcamento.AdicionarOrcamentoCompleto(orcamento, solicitacoes);

            return new AdicionarOrcamentoResponse(orcamento.Id, request.IdExterno);

        }

        private List<OrcamentoItem> PopulaItemOrcamento(List<AdicionarOrcamentoItensRequest> itens)
        {
            var orcamentoItens = new List<OrcamentoItem>();

            foreach (var item in itens)
            {
                var produto = new OrcamentoItem(item.Descricao, item.Quantidade, item.ValorUnitarioItem, item.ValorTotalItem);

                AddNotifications(produto);

                if (produto.IsValid())
                {
                    orcamentoItens.Add(produto);
                }
            }

            return orcamentoItens;
        }

        public AlterarStatusResponse AlterarStatus(AlterarStatusRequest request, Guid idUsuario)
        {
            if (request == null)
            {
                AddNotification("Resquest", "Invalido");
                return null;
            }

            var orcamento = _repositoryOrcamento.RetornarOrcamentoIdExternoIdUsuario(request.IdExterno, idUsuario);

            if (orcamento == null)
            {
                AddNotification("IdExterno", "Orçamento não localizado.");
                return null;
            }

            orcamento.AlterarStatus(request.NovoStatus);

            orcamento = _repositoryOrcamento.Editar(orcamento);

            return new AlterarStatusResponse(orcamento.IdExterno, "Status alterado com sucesso");

        }
    }
}
