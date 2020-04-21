using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Commands.Usuario.AdicionarUsuario;
using RBIntegracao.Domain.Commands.Usuario.AutenticarUsuario;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Domain.Interfaces.Services;
using RBIntegracao.Domain.ValueObjects;

namespace RBIntegracao.Domain.Services
{
    public class ServiceUsuario : Notifiable, IServiceUsuario
    {
        //Dependencias
        private readonly IRepositoryUsuario _repositoryUsuario;

        //Construtor
        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }
        public AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request)
        {
            if (request == null)
            {
                AddNotification("AdicionarUsuarioRequest", "Invalido");
                return null;
            }

            var nome = new Nome(request.RazaoSocial, request.NomeFantasia);
            var email = new Email(request.Email);

            Entities.Usuario usuario = new Entities.Usuario(nome, email, request.Senha, request.CnpjCpf, request.ClienteOuFornecedor);
            AddNotifications(usuario, nome, email);

            if (this.IsInvalid()) return null;

            //Persiste no banco de dados
            _repositoryUsuario.Adicionar(usuario);

            return new AdicionarUsuarioResponse(usuario.Id);

        }
        public AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioResquest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarUsuarioRequest", "Invalido");
                return null;
            }

            var email = new Email(request.Email);
            var usuario = new Usuario(email, request.Senha);

            AddNotifications(usuario);

            if (this.IsInvalid()) return null;

            usuario = _repositoryUsuario.ObterPor(x => x.Email.Endereco == usuario.Email.Endereco && x.Senha == usuario.Senha);

            if (usuario == null)
            {
                AddNotification("Usuario", "Dados não encontrado");
                return null;
            }

            var response = (AutenticarUsuarioResponse)usuario;

            return response;
        }
    }
}
