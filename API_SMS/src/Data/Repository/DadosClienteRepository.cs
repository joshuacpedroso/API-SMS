using Data.Context;
using DevIO.Data.Repository;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class DadosClienteRepository : Repository<DadosCliente>, IDadosClienteRepository
    {
        public DadosClienteRepository(MeuDbContext context) : base(context) { }

        public async Task<DadosCliente> ObterConteudoCliente(Guid id)
        {
            return await Db.DadosCliente.AsNoTracking()
                .Include(c => c.ConteudoCliente)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
