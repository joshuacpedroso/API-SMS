

using Domain.Models;

namespace Domain.Interfaces
{
    public interface IContatoDocumentoService
    {
        Task Adicionar (ContatoDocumento contatoDocumento);
        Task AdicionarContatos(List<ContatoDocumento> contatos);
        Task Encapsular(string filePath);
    }
}
