

using Business.Models;

namespace Bussines.Interfaces
{
    public interface IEnvioDocumentoService
    {
        Task Adicionar(EnvioDocumento documento);
    }
}
