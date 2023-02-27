using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Xml.Linq;

namespace _4Ucode_sms.Api.VewModel

{
        public class EnvioDocumentoViewModel
        {
            public Guid Id { get; set; }

            public IEnumerable<ContatoDocumentoViewModel>? Numeros { get; set; }

            public Guid NumeroId { get; set; }
            public string TextoEnvio { get; set; }

            public bool Enviado { get; set; }

            public DateTime DataCadastro { get; set; }
    }
    
}