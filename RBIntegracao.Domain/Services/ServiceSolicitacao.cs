﻿using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao;
using RBIntegracao.Domain.Commands.Solicitacao.AlterarStatus;
using RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Enums;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (_repositorySolicitacao.Existe(x => x.IdExternoSolicitacao == request.IdExternoSolicitacao && 
                                                   x.EmpresaSolicitante.Id == idUsuario))
            {
                AddNotification("Id Externo", "Já existe uma solicitação desta empresa com este Id");
                return null;
            }

            if (cliente.ClienteOuFornecedor == Enums.EnumClienteOuFornecedor.Fornecedor)
            {
                AddNotification("Usuario", "O mesmo tem que esta cadastrado como cliente, para realizar uma solicitação");
                return null;
            }

            var solicitacao = new Entities.Solicitacao(cliente, request.IdExternoSolicitacao, request.CodigoProduto, request.Descricao,
                                                       request.PrevisaoTerminoEstoque, request.QuantidadeSolicitada,
                                                       request.Observacao, request.DataValidade);

            AddNotifications(solicitacao);

            solicitacao = _repositorySolicitacao.Adicionar(solicitacao);

            var grupoFornecedor = new List<GrupoFornecedor>();

            foreach (var item in request.CnpjFornecedor)
            {
                var fornecedor = _repositoryUsuario.ObterPor(x => x.CnpjCpf.Equals(item));

                if (fornecedor == null)
                {
                    AddNotification("Fornecedor", "Não encontrado");
                    return null;
                }

                if (fornecedor.ClienteOuFornecedor == Enums.EnumClienteOuFornecedor.Cliente) 
                {
                    AddNotification("cnpjFornecedor", "O mesmo tem que esta cadastrado como Fornedor, para realizar uma solicitação");
                    return null;
                }

                if (fornecedor != null)
                    grupoFornecedor.Add(new Entities.GrupoFornecedor(fornecedor, solicitacao));
            }

            AddNotifications(grupoFornecedor);

            if (IsInvalid()) return null;

            if (grupoFornecedor.Count > 0)
            {
                _repositoryGrupoFornecedor.AdicionarLista(grupoFornecedor);
            }
            else
            {
                AddNotification("Fornecedor", "É necessário informar Fornecedor já cadastrado");
                return null;
            }


            return new AdicionarSolicitacaoResponse(solicitacao.Id, request.IdExternoSolicitacao);

        }
        public IEnumerable<ListarSolicitacaoSemOrcamentoResponse> ListarSolicitacaoFornecedor(Guid IdUsuario, int status)
        {
            if (status < 0 || status > 4)
            {
                AddNotification("Status", "Inválido");
                return null;
            }

            var statusEnum = (EnumStatus)status; 

            var solicitacaoCollection = _repositorySolicitacao.ListarSolicitacaoFornecedor(IdUsuario, statusEnum);
         
            var response = solicitacaoCollection.ToList().Select(entidade => (ListarSolicitacaoSemOrcamentoResponse)entidade);
           
            return response;
        }

        public IEnumerable<ListarSolicitacaoResponse> ListarSolicitacaoCliente(ListarSolicitacaoRequest request)
        {
            if (request == null)
            {
                AddNotification("Resquest", "Invalido");
                return null;
            }

            if (_repositoryUsuario.Existe(x => x.Id == request.Id && x.ClienteOuFornecedor == Enums.EnumClienteOuFornecedor.Fornecedor))
            {
                AddNotification("Listar SolicitacaoCliente", "Funcionalidade disponivel apenas p/ Cliente");
                return null;
            }
      
            var filtroSolicitacao = new Solicitacao(request.Id.Value, request.DataInicio, request.DataFim);

            AddNotifications(filtroSolicitacao);

            if (IsInvalid()) return null;

            var solicitacaoCollection = _repositorySolicitacao.ListarPor(x => x.EmpresaSolicitante.Id == filtroSolicitacao.Id &&
                                                                        x.DataSolicitacao.Value.Date >= filtroSolicitacao.DataInicio.Date &&
                                                                        x.DataSolicitacao.Value.Date <= filtroSolicitacao.DataFim.Date, c => c.EmpresaSolicitante).ToList();


            var solicitacaoCompleta = _repositorySolicitacao.ListarOrcamentoReferenteSolicitacao(solicitacaoCollection);

            var response = solicitacaoCompleta.ToList().Select(entidade => (ListarSolicitacaoResponse)entidade).ToList();
         
            return response;
        }

        public AlterarStatusSolicitacaoResponse AlterarStatus(AlterarStatusSolicitacaoRequest request, Guid idUsuario)
        {

            if (request == null)
            {
                AddNotification("Resquest", "Invalido");
                return null;
            }

            var solicitacao = _repositorySolicitacao.ObterPor(x => x.IdExternoSolicitacao == request.IdExterno &&
                                                                   x.EmpresaSolicitante.Id == idUsuario, c => c.EmpresaSolicitante);

            if (solicitacao == null)
            {
                AddNotification("IdExterno", "solicitacao não localizado.");
                return null;
            }

            solicitacao.AlterarStatus(request.NovoStatus);

            solicitacao = _repositorySolicitacao.Editar(solicitacao);

            return new AlterarStatusSolicitacaoResponse(solicitacao.IdExternoSolicitacao, "Status alterado com sucesso");

        }
    }
}
