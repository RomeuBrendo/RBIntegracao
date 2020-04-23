using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao;
using RBIntegracao.Domain.Commands.Usuario.AutenticarUsuario;
using RBIntegracao.Domain.Interfaces.Services;
using RBIntegracao.Infra.Repositories.Transactions;
using System.Threading.Tasks;

namespace RBIntegracao.WebApi.Controllers.Fornecedor
{
    public class Solicitacao : Base.ControllerBase
    {
        private readonly IServiceSolicitacao _serviceSolicitacao;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public Solicitacao(IHttpContextAccessor httpContextAccessor, IUnitOfWork unityOfWork, IServiceSolicitacao serviceSolicitacao) : base(unityOfWork)
        {
            _serviceSolicitacao = serviceSolicitacao;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Fornecedor/Solicitacao/Listar")]
        public async Task<IActionResult> ListarSolicitacao()
        {
            try
            {
                var request = new ListarSolicitacaoRequest();

                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _serviceSolicitacao.ListarSolicitacaoFornecedor(usuarioResponse.Id);

                return await ResponseAsync(response, _serviceSolicitacao);
            }
            catch (System.Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }

        }
    }
}
