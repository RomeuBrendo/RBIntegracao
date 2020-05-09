using prmToolkit.NotificationPattern;

namespace RBIntegracao.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email()
        {

        }
        public Email(string endereco)
        {
            Endereco = endereco;

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Endereco, "Email Inválido");
        }

        public string Endereco { get; private set; }
    }
}
