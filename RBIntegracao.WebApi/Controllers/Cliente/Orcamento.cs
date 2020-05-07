using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Commands.Usuario.AutenticarUsuario;
using RBIntegracao.Domain.Interfaces.Services;
using RBIntegracao.Infra.Repositories.Transactions;
using System.Threading.Tasks;

namespace RBIntegracao.WebApi.Controllers.Cliente
{
    public class Orcamento : Base.ControllerBase
    {
        private readonly IServiceOrcamento _serviceOrcamento;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public Orcamento(IServiceOrcamento serviceOrcamento, IHttpContextAccessor httpContextAccessor, IUnitOfWork unityOfWork) : base(unityOfWork)
        {
            _serviceOrcamento = serviceOrcamento;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpPut]
        [Route("api/Cliente/Orcamento/Alterar")]
        public async Task<IActionResult> AlterarGrupo([FromBody]AlterarStatusRequest request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                var response = _serviceOrcamento.AlterarStatus(request, usuarioResponse.Id);

                return await ResponseAsync(response, _serviceOrcamento);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
