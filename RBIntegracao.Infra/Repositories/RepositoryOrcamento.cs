using Microsoft.EntityFrameworkCore;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Enums;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RBIntegracao.Infra.Repositories
{
    public class RepositoryOrcamento : RepositoryBase<Orcamento, Guid>, IRepositoryOrcamento
    {
        private readonly RBIntegracaoContext _context;
        public RepositoryOrcamento(RBIntegracaoContext context) : base(context)
        {
            _context = context;
        }

        public Solicitacao VerificaIdExternoSolicitacao(Guid idUsuario, int idExterno)
        {

            try
            {
                var solicitacao = ( from s in _context.Solicitacao
                                from g in _context.GrupoFornecedor
                                where s.IdExternoSolicitacao == idExterno
                                where g.Fornecedor.Id == idUsuario &&
                                g.Solicitacao.Id == s.Id
                                select s).First();

                return solicitacao;
            }
            catch (Exception)
            {
                return null;
            }
               

        }

        public Orcamento AdicionarOrcamentoCompleto(Orcamento orcamento, List<Solicitacao> solicitacoes)
        {
            var orcamentoNovo = this.Adicionar(orcamento);

            if(orcamentoNovo != null)
            {
                foreach (var item in solicitacoes)
                {
                    var solicitacaoOrcamento = new SolicitacaoOrcamento();
                    solicitacaoOrcamento.Orcamento = orcamentoNovo;
                    solicitacaoOrcamento.Solicitacao = item;
                    _context.SolicitacaoOrcamento.Add(solicitacaoOrcamento);
                }

            }


            return orcamentoNovo;
        }

        public Orcamento RetornarOrcamentoIdExternoIdUsuario(int IdExterno, Guid idUsuario)
        {
            try
            {
                var orcamento = _context.SolicitacaoOrcamento.Where(x => x.Orcamento.IdExterno == IdExterno &&
                                                         x.Solicitacao.EmpresaSolicitante.Id == idUsuario)
                                                         .Select(x => x.Orcamento).First();
                return orcamento;
            }
            catch
            {

                return null; 
            }
            
        }
    }
}

