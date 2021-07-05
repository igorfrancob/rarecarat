using core.rarecarat;
using data.rarecarat.Context;
using data.rarecarat.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace data.rarecarat.Repository
{
    public interface IDiamondRepository : IAsyncRepository<Diamond>
    {
        Task<List<Diamond>> GetAllAsync();
    }

    public class DiamondRepository : EFBaseRepository<Diamond>, IDiamondRepository
    {
        public DiamondRepository( RarecaratContext dbContext ) : base( dbContext ) { }

        protected override object GetIdFrom( Diamond entity )
        {
            return ( entity.Id );
        }

        public Task<List<Diamond>> GetAllAsync()
        {
            return db.Diamonds
                    .Include( p => p.Retailer )
                    .Include( p => p.Images )
                .ToListAsync();
        }
    }
}
