using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ConteudoClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(450, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Texto { get; set; }
        public TextoClienteEnum Ativo { get; set; }

    }
    public class DadosClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string NomeCliente { get; set; }

        public int CountEnvios { get; set; }

    }

    public class PostDadosClienteViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(25, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string NomeCliente { get; set; }
    }

}
