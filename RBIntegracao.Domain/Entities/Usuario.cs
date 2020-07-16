using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Entities.Base;
using RBIntegracao.Domain.Enums;
using RBIntegracao.Domain.Extensions;
using RBIntegracao.Domain.ValueObjects;

namespace RBIntegracao.Domain.Entities
{
    public class Usuario : EntityBase
    {
        protected Usuario()
        {

        }
        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            Senha = Senha.ConvertToMD5();

            AddNotifications(email);
        }

        public Usuario(Nome nome, Email email, string senha, string cnpjCpf, EnumClienteOuFornecedor clienteOuFornecedor)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            CnpjCpf = cnpjCpf;
            ClienteOuFornecedor = clienteOuFornecedor;

            ValidaCpfCnpj();

            new AddNotifications<Usuario>(this)
                .IfEnumInvalid(x => x.ClienteOuFornecedor, "Opção só pode ser preenchida com numerais, 0 - cliente | 1 - Fornecedor | 2 - Ambos");
                

            //AddNotifications(nome, email);

            //Criptografo a senha
            Senha = Senha.ConvertToMD5();
        }

        public Usuario(string cnpjCpf)
        {
            CnpjCpf = cnpjCpf;

            ValidaCpfCnpj();
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public string CnpjCpf { get; private set; }
        public EnumClienteOuFornecedor ClienteOuFornecedor { get; private set; }

        public void ValidaCpfCnpj()
        {
            if (this.CnpjCpf.Length != 11)
            {
                new AddNotifications<Usuario>(this)
                    .IfNotCpf(x => x.CnpjCpf, "CPF Inválido");
            }
            else 
            {
                new AddNotifications<Usuario>(this)
                    .IfNotCnpj(x => x.CnpjCpf, "CNPJ Inválido");
            }

               
        }
    }
}
