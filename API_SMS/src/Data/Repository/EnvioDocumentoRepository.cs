using Data.Context;
using DevIO.Data.Repository;
using Domain.Interfaces;
using Domain.Models;

namespace Data.Repository
{
    public class EnvioDocumentoRepository : Repository<EnvioDocumento>, IEnvioDocumentoRepository
    {
        public EnvioDocumentoRepository(MeuDbContext context) : base(context) {}
    }
}