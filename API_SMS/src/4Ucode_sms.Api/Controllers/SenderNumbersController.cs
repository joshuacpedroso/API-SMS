using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Interfaces;
using _4Ucode_sms.Api.VewModel;
using Domain.Models;
using Data.Repository;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("api/envio")]
    //[ApiController]
    public class SenderNumbersController : MainController
    {
        private readonly IEnvioDocumentoService _envioDocumentoService;
        private readonly IEnvioDocumentoRepository _envioDocumentoRepository;
        private readonly ITwilloService _twilloService;
        private readonly IMapper _mapper;


        public SenderNumbersController(
            INotificador notificador,
            IMapper mapper,
            IUser user,
            ITwilloService twilloService,
            IEnvioDocumentoRepository envioDocumentoRepository,
            IEnvioDocumentoService envioDocumentoService) : base(notificador,user)
        {
            _mapper = mapper;
            _twilloService = twilloService;
            _envioDocumentoService = envioDocumentoService;
            _envioDocumentoRepository = envioDocumentoRepository;
        }


        [HttpPost]
        public async Task<ActionResult<PostDocumentoViewModel>> PostSender(List<PostDocumentoViewModel> postDocumentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _envioDocumentoService.AdicionarEnvios(_mapper.Map<List<EnvioDocumento>>(postDocumentoViewModel));

            return CustomResponse(postDocumentoViewModel);
        }


        [HttpGet]
        public async Task<IEnumerable<EnvioDocumentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EnvioDocumentoViewModel>>(await _envioDocumentoRepository.ObterTodos());
        }
    }
}
