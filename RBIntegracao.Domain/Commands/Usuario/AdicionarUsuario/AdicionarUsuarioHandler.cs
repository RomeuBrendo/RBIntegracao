using MediatR;
using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Domain.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace RBIntegracao.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarUsuarioHandler(IMediator mediator, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            //Validar se o requeste veio preenchido
            if (request == null)
            {
                AddNotification("Resquest", "Invalido");
                return new Response(this);
            }

            //Verificar se o usuário já existe
            if (_repositoryUsuario.Existe(x => x.Email.Endereco == request.Email))
            {
                AddNotification("Email", "Email já existente");
                return new Response(this);
            }

            var nome = new Nome(request.RazaoSocial, request.NomeFantasia);
            var email = new Email(request.Email);

            Entities.Usuario usuario = new Entities.Usuario(nome, email, request.Senha,request.CnpjCpf,  request.ClienteOuFornecedor);
            AddNotifications(usuario, nome, email);

            if (IsInvalid())
            {
                return new Response(this);
            }

            usuario = _repositoryUsuario.Adicionar(usuario);

            //Criar meu objeto de resposta
            var response = new Response(this, usuario);

           // AdicionarUsuarioNotification adicionarUsuarioNotification = new AdicionarUsuarioNotification(usuario);

           // await _mediator.Publish(adicionarUsuarioNotification);

            return await Task.FromResult(response);
        }
    }

}
