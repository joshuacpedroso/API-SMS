using _4Ucode_sms.Bussines.Notificacoes;

namespace Business.Interfaces
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