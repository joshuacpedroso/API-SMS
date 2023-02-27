using Domain.Models.Enums;

namespace Domain.Models
{
    public class ConteudoCliente : Entity
    {
        public string Texto { get; set; }
        public Guid IdCliente { get; set; }
        public TextoClienteEnum Ativo { get; set; }
        public DadosCliente DadosCliente { get; set; }
        //public IEnumerable<DadosCliente> DadosCliente { get; set; }
    }
    public class DadosCliente : Entity
    {
        public string NomeCliente { get; set; }
        
        public int CountEnvios { get; set; }


        public IEnumerable<ConteudoCliente> ConteudoCliente { get; set; }

        public IEnumerable<EnvioDocumento> EnvioDocumentos { get; set; }
    }
}
