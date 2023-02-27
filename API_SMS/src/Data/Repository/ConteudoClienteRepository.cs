using Data.Context;
using DevIO.Data.Repository;
using Domain.Interfaces;
using Domain.Models;

namespace Data.Repository
{
    public class ConteudoClienteRepository : Repository<ConteudoCliente>, IConteudoClienteRepository
    {
        public ConteudoClienteRepository(MeuDbContext context) : base(context) {}
    }
}