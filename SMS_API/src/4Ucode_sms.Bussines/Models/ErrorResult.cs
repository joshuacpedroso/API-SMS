using _4Ucode_sms.Bussines.Notificacoes;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Business.Models
{
    public class ErrorResult
    {
        [JsonConstructor]
        public ErrorResult() { }

        public ErrorResult(params Notificacao[] errors)
        {
            Errors = errors;
        }

        public ErrorResult(IEnumerable<Notificacao> errors) : this(errors.ToArray()) { }

        public ErrorResult(params string[] errors)
        {
            Errors = errors.Select(str => new Notificacao(str));
        }
        public ErrorResult(IEnumerable<string> errors) : this(errors.ToArray()) { }

        public bool Success { get; set; }

        public IEnumerable<Notificacao> Errors { get; set; }
    }
}
