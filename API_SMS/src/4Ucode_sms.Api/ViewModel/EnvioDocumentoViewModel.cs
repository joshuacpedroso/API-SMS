
using Domain.Models.Enums;

namespace _4Ucode_sms.Api.VewModel

{
    public class EnvioDocumentoViewModel
    {
        public Guid Id { get; set; }
        public Guid NumeroId { get; set; }

        public Guid ClienteId { get; set; }
        public string TextoEnvio { get; set; }

        public EnvioEnum Enviado { get; set; }

        public DateTime DataCadastro { get; set; }
    }
    public class PostDocumentoViewModel
    {
        public Guid Id { get; set; }
        public string TextoEnvio { get; set; }
        public Guid NumeroId { get; set; }

        public Guid ClienteId { get; set; }


    }
}