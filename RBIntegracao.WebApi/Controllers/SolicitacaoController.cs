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
using RBIntegracao.Domain.Interfaces.Services;

namespace RBIntegracao.WebApi.Controllers
{
    public class SolicitacaoController : Base.ControllerBase
    {
        private readonly IServiceSolicitacao _serviceSolicitacao;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public SolicitacaoController(IHttpContextAccessor httpContextAccessor, IUnitOfWork unityOfWork, IServiceSolicitacao serviceSolicitacao) : base(unityOfWork)
        {
            _serviceSolicitacao = serviceSolicitacao;
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

                var response = _serviceSolicitacao.AdicionarSolicitacao(request, usuarioResponse.Id);

                return await ResponseAsync(response, _serviceSolicitacao);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        //[Authorize]
        //[HttpPost]
        //[Route("api/Solicitacao/ListarPorFornecedor")]
        //public async Task<IActionResult> ListarSolicitacao()
        //{
        //    try
        //    {
        //        var request = new ListarSolicitacaoRequest();

        //        string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
        //        AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

        //        request.Id = usuarioResponse.Id;
        //        var response = await _mediator.Send(request, CancellationToken.None);

        //        return Ok(response);
        //    }
        //    catch (System.Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }

        //}
    }
}
