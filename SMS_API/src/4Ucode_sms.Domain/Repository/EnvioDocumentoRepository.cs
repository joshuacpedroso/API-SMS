using _4Ucode_sms.Data.Context;
using Business.Models;
using DevIO.Data.Repository;

namespace Data.Repository
{
    public class EnvioDocumentoRepository : Repository<EnvioDocumento>, IEnvioDocumentoRepository
    {
        public EnvioDocumentoRepository(MeuDbContext context) : base(context) {}
    }
}