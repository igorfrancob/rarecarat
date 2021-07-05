
namespace core.rarecarat
{
    public interface IRepository<T> where T : IEntity
    {
        object Create( T entity );

        void Update( T entity );

        void Delete( object id );

        void RemoveListElements( T entity );

        T GetById( object id );

        T GetBaseEntityById( object id );
        
    }
}