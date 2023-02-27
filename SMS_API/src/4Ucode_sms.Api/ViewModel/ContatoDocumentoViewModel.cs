using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Xml.Linq;

namespace _4Ucode_sms.Api.VewModel

{
        public class ContatoDocumentoViewModel
        {
            public Guid Id { get; set; }

            public string numero { get; set; }

            public DateTime DataCadastro { get; set; }
        }
    
}