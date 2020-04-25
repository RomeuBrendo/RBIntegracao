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
        public Solicitacao(Usuario empresaSolicitante, int idExternoSolicitacao, int codigoProduto, string descricao, DateTime? previsaoTermino, double quantidadeSolicitada, string observacao, DateTime dataValidade)
        {
            IdExternoSolicitacao = idExternoSolicitacao;
            EmpresaSolicitante = empresaSolicitante;
            CodigoProduto = codigoProduto;
            Descricao = descricao;
            PrevisaoTermino = previsaoTermino;
            QuantidadeSolicitada = quantidadeSolicitada;
            Status = EnumStatus.Aberta;
            Observacao = observacao;
            DataValidade = dataValidade;

            new AddNotifications<Solicitacao>(this)
                .IfNullOrEmpty(x => x.Descricao, "Descrição do produto não pode ser vazia");

            ValidaNumerais();

            DataSolicitacao = DateTime.Now;
        }

        public Solicitacao(Guid id, string dataInicio, string dataFim)
        {
            try
            {
                Id = id;
                DataInicio = Convert.ToDateTime(dataInicio);
                DataFim = Convert.ToDateTime(dataFim);
            }
            catch (Exception)
            {

                AddNotification("Data ", "Verifique Data Inicio e Data Fim.");
            }

            if((this.DataInicio) > (this.DataFim))
                AddNotification("Data ", "Data inicio não pode ser superior a data fim.");

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

        //Propriedade apenas para validar data da listagem
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }

        public DateTime DataValidade { get; private set; }

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
