using MediatR;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao
{
    public class AdicionarSolicitacaoRequest : IRequest<Response>
    {

        public Guid ? IdUsuario { get; set; }
        public int CodigoProduto { get; set; }

        public string Descricao { get; set; }

        public DateTime? PrevisaoTerminoEstoque { get; set; }

        public double QuantidadeSolicitada { get; set; }

        public EnumStatus Status { get; set; }

        public string Observacao { get; set; }

        public List<string> CnpjFornecedor { get; set; }
    }
}
