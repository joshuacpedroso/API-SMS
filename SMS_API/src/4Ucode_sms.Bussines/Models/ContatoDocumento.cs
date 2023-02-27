using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Xml.Linq;

namespace Business.Models

{
        public class ContatoDocumento : Entity
        {
            public string numero { get; set; }
           
            public IEnumerable<EnvioDocumento> EnvioDocumentos { get; set; }
        }
    
}