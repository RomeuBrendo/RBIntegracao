using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao;
using RBIntegracao.Domain.Entities.Base;
using RBIntegracao.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RBIntegracao.Domain.Entities
{
    public class Solicitacao : EntityBase
    {
        protected Solicitacao()
        {

        }
        public Solicitacao(Usuario empresaSolicitante, int idExternoSolicitacao, int codigoProduto, string descricao, DateTime? previsaoTermino, double quantidadeSolicitada, string observacao)
        {
            idExternoSolicitacao = IdExternoSolicitacao;
            EmpresaSolicitante = empresaSolicitante;
            CodigoProduto = codigoProduto;
            Descricao = descricao;
            PrevisaoTermino = previsaoTermino;
            QuantidadeSolicitada = quantidadeSolicitada;
            Status = EnumStatus.Aberta;
            Observacao = observacao;

            new AddNotifications<Solicitacao>(this)
                .IfNullOrEmpty(x => x.Descricao, "Descrição do produto não pode ser vazia");

            ValidaNumerais();

            DataSolicitacao = DateTime.Now;
        }

        public Usuario EmpresaSolicitante { get; private set; }

        public int IdExternoSolicitacao { get; private set; }
        public int CodigoProduto { get; private set; }

        public string Descricao { get; private set; }

        public DateTime? PrevisaoTermino { get; private set; }

        public double QuantidadeSolicitada { get; private set; }

        public EnumStatus Status { get; private set; }

        public string Observacao { get; private set; }

        public DateTime? DataSolicitacao { get; private set; }

        private void ValidaNumerais()
        {
            if (this.CodigoProduto <= 0)
                AddNotification("Codigo Produto ", "Inválido");

            if (this.QuantidadeSolicitada <= 0)
                AddNotification("Quantidade Solicitada", "Inválida");
            
            if (this.IdExternoSolicitacao <= 0)
                AddNotification("IdExternoSolicitacao", "Inválido");
        }

    }
}
