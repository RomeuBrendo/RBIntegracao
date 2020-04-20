using prmToolkit.NotificationPattern;


namespace RBIntegracao.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        protected Nome()
        {

        }
        public Nome(string razaoSocial, string nomeFantasia)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.RazaoSocial, 1, 500)
                .IfNullOrInvalidLength(x => x.NomeFantasia, 1, 500);
        }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
    }
}
