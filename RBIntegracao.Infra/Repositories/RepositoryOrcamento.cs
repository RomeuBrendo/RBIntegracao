using Microsoft.EntityFrameworkCore;
using RBIntegracao.Domain.Entities;
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

        public bool VerificaIdExternoSolicitacao(Guid IdUsuario, int idExterno)
        {
            var solicitacao = ( from s in _context.Solicitacao
                                from g in _context.GrupoFornecedor
                                where s.IdExternoSolicitacao == idExterno
                                where g.Fornecedor.Id == IdUsuario &&
                                g.Solicitacao.Id == s.Id
                                select s).ToList();

            if (solicitacao.Count == 0)
                return false;

            return true;

        }
    }
}
//IEnumerable<Solicitacao> solicitacoes = (from f in _context.GrupoFornecedor
//                                         from s in _context.Solicitacao
//                                         where f.Fornecedor.Id == idFornecedor &&
//                                         s.Id == f.Solicitacao.Id
//                                         select s).Include(c => c.EmpresaSolicitante).ToList();
            
//            return solicitacoes;