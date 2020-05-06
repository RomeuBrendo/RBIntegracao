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
                var usuario = _context.Usuario.FirstOrDefault(x => x.Id == idUsuario);

                if (usuario.ClienteOuFornecedor == EnumClienteOuFornecedor.Cliente)
                {
                    var orcamento = _context.SolicitacaoOrcamento.Where(x => x.Orcamento.IdExterno == IdExterno &&
                                         x.Solicitacao.EmpresaSolicitante.Id == idUsuario)
                                         .Select(x => x.Orcamento).First();
                    return orcamento;
                }
                else
                {
                    //Ainda não está sendo usando, precisa ser revisto.
                    var orcamento = _context.SolicitacaoOrcamento.Where(x => x.Orcamento.IdExterno == IdExterno &&
                                         x.Orcamento.FornecedorSolicitante.Id == idUsuario)
                                         .Select(x => x.Orcamento).Include(x => x.Itens)
                                         .First();
                                         
                    
              
                    return orcamento;
                }

            }
            catch
            {

                return null; 
            }
        }

        public bool DeletarOrcamentoCompleto(int IdExterno, Guid idUsuario)
        {
            try
            {
                var orcamentoSolicitacao = (from s in _context.SolicitacaoOrcamento
                                            where s.Orcamento.IdExterno == IdExterno &&
                                            s.Orcamento.FornecedorSolicitante.Id == idUsuario
                                            select s)
                                            .Include(x => x.Orcamento).Include(x => x.Orcamento.Itens)
                                            .FirstOrDefault();

                if (orcamentoSolicitacao == null)
                    return false;

                var itensOrcamento = _context.OrcamentoItem.Where(x => x.OrcamentoId == orcamentoSolicitacao.Orcamento.Id);

                if (itensOrcamento == null)
                    return false;

                _context.OrcamentoItem.RemoveRange(itensOrcamento);
                _context.Orcamento.Remove(orcamentoSolicitacao.Orcamento); 
                _context.SolicitacaoOrcamento.Remove(orcamentoSolicitacao);

                return true;
            }
            catch
            {

                return false;
            }

        }
    }
}

