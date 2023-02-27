using Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _4Ucode_sms.Bussines.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;

        public int Count => _notificacoes.Count;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }
        public void Handle(IEnumerable<Notificacao> notificacoes)
        {
            _notificacoes.AddRange(notificacoes);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool HasNotifications()
        {
            return _notificacoes.Any();
        }
        public void Clear()
        {
            _notificacoes.Clear();
        }
    }
}
