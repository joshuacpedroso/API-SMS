using Data.Context;
using DevIO.Data.Repository;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.ModelTwillo;

namespace Data.Repository
{
    public class TwilloRepository : Repository<TwilloModel>, ITwilloRepository
    {
        public TwilloRepository(MeuDbContext context) : base(context) {}
    }
}