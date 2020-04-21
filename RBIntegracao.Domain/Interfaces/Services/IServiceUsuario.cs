using RBIntegracao.Domain.Commands.Usuario.AdicionarUsuario;
using RBIntegracao.Domain.Commands.Usuario.AutenticarUsuario;
using RBIntegracao.Domain.Interfaces.Services.Base;

namespace RBIntegracao.Domain.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase
    {
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request);
        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioResquest request);
    }
}
