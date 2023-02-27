using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Bussines.Interfaces;
using Data.Repository;

namespace _4Ucode_sms.Bussines.Services
{
    public class EnvioDocumentoService : BaseService, IEnvioDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IEnvioDocumentoRepository _envioDocumentoRepository;

        public EnvioDocumentoService(IEnvioDocumentoRepository documento,INotificador notificador, IMapper mapper) : base(notificador)
        {
            _mapper = mapper;
            _envioDocumentoRepository = documento;  
        }

        public Task GetDocuments<UploadDocumentResponse>(Guid operatorId)
        {
            throw new NotImplementedException();
        }


        public async Task Adicionar(EnvioDocumento documento)
        {
            await _envioDocumentoRepository.Adicionar(documento);
        }
    }
}
