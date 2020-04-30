using Microsoft.EntityFrameworkCore;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RBIntegracao.Infra.Repositories
{
    public class RepositorySolicitacao : RepositoryBase<Solicitacao, Guid>, IRepositorySolicitacao
    {
        private readonly RBIntegracaoContext _context;
        public RepositorySolicitacao(RBIntegracaoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Solicitacao> ListarSolicitacaoFornecedor(Guid idFornecedor)
        {
       

            IEnumerable<Solicitacao> solicitacoes = (from f in _context.GrupoFornecedor
                                    from s in _context.Solicitacao
                                    where f.Fornecedor.Id == idFornecedor &&
                                    s.Id == f.Solicitacao.Id
                                    select s).Include(c => c.EmpresaSolicitante).ToList();
            
            return solicitacoes;
        }
    }
}
