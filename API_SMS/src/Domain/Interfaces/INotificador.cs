
using Domain.Notificacoes;

namespace Domain.Interfaces
{
    public interface INotificador
    {
        bool HasNotifications();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
        void Handle(IEnumerable<Notificacao> notificacoes);
        void Clear();
        int Count { get; }
    }
}