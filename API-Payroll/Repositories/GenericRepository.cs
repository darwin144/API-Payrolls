using API_eSIP.Contracts;

namespace API_eSIP.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        TEntity? IGenericRepository<TEntity>.Create(TEntity item)
        {
            throw new NotImplementedException();
        }

        bool IGenericRepository<TEntity>.Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IGenericRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        TEntity? IGenericRepository<TEntity>.GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        bool IGenericRepository<TEntity>.Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
