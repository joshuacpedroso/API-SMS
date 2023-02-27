using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Interfaces;
using _4Ucode_sms.Api.VewModel;
using Domain.Models;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("api/contatos")]
    //[ApiController]
    public class UploadController : MainController
    {
        private readonly IContatoDocumentoService _contatoDocumentoService;
        private readonly IContatoDocumentoRepository _contatoDocumentoRepository;
        private readonly ITwilloService _twilloService;
        private readonly IMapper _mapper;


        public UploadController(
            INotificador notificador,
            IMapper mapper,
            IUser user,
            ITwilloService twilloService,
            IContatoDocumentoRepository contatoDocumentoRepository,
            IContatoDocumentoService baseUploadService) : base(notificador,user)
        {
            _contatoDocumentoService = baseUploadService;
            _mapper = mapper;
            _contatoDocumentoRepository = contatoDocumentoRepository;
            _twilloService = twilloService;
        }

        [HttpPost("Upload_file")]
        public async Task<IActionResult> Documento(IFormFile arquivo)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/path_txts/" + arquivo.FileName);
                if (arquivo.Length > 0)
                {
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await arquivo.CopyToAsync(stream);
                }         
            await _contatoDocumentoService.Encapsular(filePath);
            return CustomResponse();
        }


        [HttpPost]
        public async Task<ActionResult<ContatoPostModel>> PostContatos(List<ContatoPostModel> contatoPostModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _contatoDocumentoService.AdicionarContatos(_mapper.Map<List<ContatoDocumento>>(contatoPostModel));

            return CustomResponse(contatoPostModel);
        }


        [HttpGet]
        public async Task<IEnumerable<ContatoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoDocumentoRepository.ObterTodos());
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContatoViewModel>> ObterPorId(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            
            var contato = _mapper.Map<ContatoViewModel>(await _contatoDocumentoRepository.ObterPorId(id));

            if (contato == null) return NotFound();

            return contato;
        }




    }
}
