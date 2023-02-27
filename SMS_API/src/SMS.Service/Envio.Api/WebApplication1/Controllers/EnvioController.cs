using Envio.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Envio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : MainController
    {
        private readonly IEnvioService _envioService;

        public EnvioController(EnvioService envioService, INotificador notificador) : base(notificador)
        {
            _envioService = envioService;
        }

        [HttpPost("envio")]
        public async Task<IActionResult> EnviarMensagem(string mensagem)
        {
            var envio = _envioService.SendSMS(mensagem);
            return CustomResponse();
            

        }
    }
}
