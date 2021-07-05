namespace domain.rarecarat.Contracts.Base
{
	public interface IGenericPersistBusiness<TEntity> where TEntity : class
	{
		object Save(TEntity obj, string idUser);
		object Update(TEntity obj, string idUser);
		object Delete(TEntity obj);
	}
}
