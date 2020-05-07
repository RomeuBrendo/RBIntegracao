using Microsoft.EntityFrameworkCore;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Enums;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace RBIntegracao.Infra.Repositories
{
    public class RepositorySolicitacao : RepositoryBase<Solicitacao, Guid>, IRepositorySolicitacao
    {
        private readonly RBIntegracaoContext _context;
        public RepositorySolicitacao(RBIntegracaoContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Solicitacao> ListarSolicitacaoFornecedor(Guid idFornecedor, EnumStatus status)
        {
       
            var solicitacoes = (from f in _context.GrupoFornecedor
                                    from s in _context.Solicitacao
                                    where f.Fornecedor.Id == idFornecedor &&
                                    s.Id == f.Solicitacao.Id 
                                    select s).Include(c => c.EmpresaSolicitante).ToList();

            if (status != EnumStatus.Todos)
                solicitacoes.RemoveAll(x => x.Status != status);

            return solicitacoes;
        }

        public IEnumerable<Solicitacao> ListarOrcamentoReferenteSolicitacao(List<Solicitacao> solicitacoes)
        {

            foreach (var item in solicitacoes)
            {
                item.Orcamentos = (from so in _context.SolicitacaoOrcamento
                                   from o in _context.Orcamento
                                   where so.Solicitacao.Id == item.Id &&
                                   so.Orcamento.Id == o.Id
                                   select o).Include(x => x.Itens).ToList();
            }

            return solicitacoes;
        }
    }
}
