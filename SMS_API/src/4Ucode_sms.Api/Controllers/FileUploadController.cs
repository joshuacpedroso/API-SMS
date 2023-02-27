using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Business.Interfaces;
using Bussines.Interfaces;
using _4Ucode_sms.Api.VewModel;
using System.ComponentModel.DataAnnotations;
using Business.Intefaces;

namespace _4Ucode_sms.Api.Controllers
{
    [Route("api/Arquivo")]
    //[ApiController]
    public class FileUploadController : MainController
    {
        private readonly IContatoDocumentoService _contatoDocumentoService;
        private readonly IMapper _mapper;


        public FileUploadController(
            INotificador notificador,
            IMapper mapper,
            IUser user,
            IContatoDocumentoService baseUploadService) : base(notificador,user)
        {
            _contatoDocumentoService = baseUploadService;
            _mapper = mapper;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Documento(IFormFile arquivo)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Save_Backup_" + arquivo.FileName);

                if (arquivo.Length > 0)
                {


                    using var stream = new FileStream(filePath, FileMode.Create);


                    await arquivo.CopyToAsync(stream);


                }
            

            await _contatoDocumentoService.Encapsular(filePath);

            

            

            return CustomResponse();
        }
    }
}
