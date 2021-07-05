using System;
using System.Linq;

namespace core.rarecarat
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>( Type repositoryType ) where TEntity : IEntity;

        TRepository Repository<TRepository>();

        //void SaveChanges();

        void BeginTransaction();

        int Commit();

        void Rollback();

        //void TryRollback( CurrentLogContext logContext );

        string User { get; set; }

        IQueryable<TElement> SqlQuery<TElement>( string sql, params object[] parameters );
    }
}