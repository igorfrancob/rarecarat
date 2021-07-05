using core.rarecarat;
using data.rarecarat.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace data.rarecarat.Repository
{
    public abstract class EFBaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly RarecaratContext db;

        protected EFBaseRepository( RarecaratContext dbContext ) : base()
        {
            db = dbContext;
            //_logger = CoreConfigurations.Logger;
        }

        public Task<object> CreateAsync( TEntity entity )
        {
            db.Set<TEntity>().AddAsync( entity );
            db.SaveChangesAsync();
            return Task.Factory.StartNew( () => GetIdFrom( entity ) );
        }

        public Task UpdateAsync( TEntity entity )
        {
            if ( !db.ChangeTracker.Entries<TEntity>().Any( x => x.Entity == entity ) )
            {
                db.Set<TEntity>().Attach( entity );
                db.Entry( entity ).State = EntityState.Modified;
            }

            return db.SaveChangesAsync();
        }

        public async Task DeleteAsync( object id )
        {
            var entity = await db.Set<TEntity>().FindAsync( id );
            if ( entity == null )
                throw new ArgumentException( string.Format( "Entity not found for id {0}", id ) );
            db.Entry( entity ).State = EntityState.Deleted;

            await db.SaveChangesAsync();
        }

        public ValueTask<TEntity> GetByIdAsync( object id )
        {
            return db.Set<TEntity>().FindAsync( id );
        }

        protected abstract object GetIdFrom( TEntity entity );
    }
}