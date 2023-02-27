using Data.Context;
using DevIO.Data.Repository;
using Domain.Interfaces;
using Domain.Models;

namespace Data.Repository
{
    public class ContatoDocumentoRepository : Repository<ContatoDocumento>, IContatoDocumentoRepository
    {
        public ContatoDocumentoRepository(MeuDbContext context) : base(context) {}
    }
}