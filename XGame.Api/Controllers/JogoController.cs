using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XGame.Api.Controllers.Base;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Interfaces.Services;
using XGame.Infra.Transactions;

namespace XGame.Api.Controllers
{

    [RoutePrefix("api/Jogo")]
    public class JogoController : ControllerBase
    {

        private readonly IServiceJogo _serviceJogo;

        public JogoController(IUnitOfWork unitOfWork, IServiceJogo serviceJogo) : base(unitOfWork)
        {
            _serviceJogo = serviceJogo;
        }

        [Route("adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.AdicionarJogo(request);

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("alterar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Alterar(AlterarJogoRequest request)
        {
            try
            {
                var response = _serviceJogo.AlterarJogo(request);

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Authorize]
        [Route("excluir")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Excluir(Guid id)
        {
            try
            {
                var response = _serviceJogo.ExcluirJogo(id);

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceJogo.ListarJogo();

                return await ResponseAsync(response, _serviceJogo);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

    }

}