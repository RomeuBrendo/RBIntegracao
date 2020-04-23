﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao
{
    public class ListarSolicitacaoResponse
    {
        public Guid IdSolicitacao { get; set; }
        public String EmpresaSolicitante { get; set; }
        public String EmpresaSolicitanteCNPJCPF { get; set; }

        public int CodigoProduto { get; private set; }

        public string Descricao { get; private set; }

        public DateTime? PrevisaoTerminoEstoque { get; private set; }

        public double QuantidadeSolicitada { get; private set; }

        public string Status { get; private set; }

        public string Observacao { get; private set; }

        public DateTime? DataSolicitacao { get; private set; }

        public static explicit operator ListarSolicitacaoResponse(Entities.Solicitacao entidade)
        {
            return new ListarSolicitacaoResponse()
            {
                IdSolicitacao = entidade.Id,
                EmpresaSolicitanteCNPJCPF = entidade.EmpresaSolicitante.CnpjCpf,
                EmpresaSolicitante = entidade.EmpresaSolicitante.Nome.RazaoSocial,
                CodigoProduto = entidade.CodigoProduto,
                Descricao = entidade.Descricao,
                PrevisaoTerminoEstoque = entidade.PrevisaoTermino,
                QuantidadeSolicitada = entidade.QuantidadeSolicitada,
                Status = entidade.Status.ToString(),
                Observacao = entidade.Observacao,
                DataSolicitacao = entidade.DataSolicitacao

            };
        }

    }
}
