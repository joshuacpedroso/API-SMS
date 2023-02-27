using FluentValidation.Results;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Domain.Notificacoes
{
    [DebuggerDisplay("{Type}:{Code} {Mensagem}")]
    public class Notificacao
    {
        [JsonConstructor]
        public Notificacao(string code, string mensagem, ENotificationType type)
        {
            Code = code;
            Mensagem = mensagem;
            Type = type;
        }
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
            Type = ENotificationType.Warning;
        }

        public string Code { get; }
        public string Mensagem { get; }
        public ENotificationType Type { get; }

        public static implicit operator Notificacao(ValidationFailure v) => new(v.ErrorMessage);

        public static implicit operator Notificacao(string str) => new(str);

    }
}
