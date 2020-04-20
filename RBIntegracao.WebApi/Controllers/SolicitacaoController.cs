using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using RBIntegracao.Domain.Commands.Usuario.AutenticarUsuario;
using RBIntegracao.Infra.Repositories.Transactions;
using RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao;
using RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao;

namespace RBIntegracao.WebApi.Controllers
{
    public class SolicitacaoController : Base.ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SolicitacaoController(IHttpContextAccessor httpContextAccessor, IMediator mediator, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Solicitacao/Adicionar")]
        public async Task<IActionResult> AdicionarSolicitacao([FromBody]AdicionarSolicitacaoRequest request)
        {
            try
            {
                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                request.IdUsuario = usuarioResponse.Id;

                var response = await _mediator.Send(request, CancellationToken.None);
                return await ResponseAsync(response);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [Authorize]
        [HttpPost]
        [Route("api/Solicitacao/ListarPorFornecedor")]
        public async Task<IActionResult> ListarSolicitacao()
        {
            try
            {
                var request = new ListarSolicitacaoRequest();

                string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
                AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

                request.Id = usuarioResponse.Id;
                var response = await _mediator.Send(request, CancellationToken.None);

                return Ok(response);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
