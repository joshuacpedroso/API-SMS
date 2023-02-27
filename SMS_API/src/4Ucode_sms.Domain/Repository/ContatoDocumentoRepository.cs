using _4Ucode_sms.Data.Context;
using Business.Models;
using DevIO.Data.Repository;

namespace Data.Repository
{
    public class ContatoDocumentoRepository : Repository<ContatoDocumento>, IContatoDocumentoRepository
    {
        public ContatoDocumentoRepository(MeuDbContext context) : base(context) {}
    }
}