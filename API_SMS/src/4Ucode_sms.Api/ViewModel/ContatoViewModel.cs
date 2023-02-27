
using System.ComponentModel.DataAnnotations;

namespace _4Ucode_sms.Api.VewModel

{
        public class ContatoViewModel
        {
            public Guid Id { get; set; }

            public string numero { get; set; }

            public DateTime DataCadastro { get; set; }
        }
        public class ContatoPostModel
        {
        [Phone]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(13, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string numero { get; set; }


        }


}