using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Commands.Orcamento.ListarOrcamento;
using RBIntegracao.Domain.Commands.Usuario.AutenticarUsuario;
using RBIntegracao.Domain.Interfaces.Services;
using RBIntegracao.Infra.Repositories.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBIntegracao.WebApi.Controllers.Fornecedor
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
        [HttpPost]
        [Route("api/Fornecedor/Orcamento/Adicionar")]
        public async Task<IActionResult> AdicionarOrcamento([FromBody]AdicionarOrcamentoRequest request)
        {
            try
            {
                var response = _serviceOrcamento.AdicionarOrcamento(request, RetornaIdUsuarioLogado());

                return await ResponseAsync(response, _serviceOrcamento);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpDelete]
        [Route("api/Fornecedor/Orcamento/Deletar/{idExterno:int}")]
        public async Task<IActionResult> DeletarOrcamento(int idExterno)
        {
            try
            {

                var result = _serviceOrcamento.Deletar(idExterno, RetornaIdUsuarioLogado());

                return await ResponseAsync(result, _serviceOrcamento);

            }
            catch (System.Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/Fornecedor/Orcamento/ListarPorData")]
        public async Task<IActionResult> ListarSolicitacao(ListarOrcamentoRequest request)
        {
            try
            {

                request.Id = RetornaIdUsuarioLogado();

                var response = _serviceOrcamento.ListarOrcamentoPorData(request);

                return await ResponseAsync(response, _serviceOrcamento);
            }
            catch (System.Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }

        }
        public Guid RetornaIdUsuarioLogado()
        {
            string usuarioClaims = _httpContextAccessor.HttpContext.User.FindFirst("Usuario").Value;
            AutenticarUsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<AutenticarUsuarioResponse>(usuarioClaims);

            return usuarioResponse.Id;

        }
    }
}
