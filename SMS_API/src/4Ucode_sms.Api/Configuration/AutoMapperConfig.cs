using _4Ucode_sms.Api.VewModel;
using AutoMapper;
using Business.Models;

namespace _4Ucode_sms.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ContatoDocumentoViewModel, ContatoDocumento>().ReverseMap();
            CreateMap<EnvioDocumentoViewModel, EnvioDocumento>().ReverseMap();

        }
    }
}
