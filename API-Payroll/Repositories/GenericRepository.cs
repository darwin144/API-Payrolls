using API_Payroll.Context;
using API_Payroll.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace API_Payroll.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly PayrollOvertimeContext _context;
        public GenericRepository(PayrollOvertimeContext context)
        {
            _context = context;
        }
        public TEntity? Create(TEntity item)
        {
            try
            {
                _context.Set<TEntity>().Add(item);
                _context.SaveChanges();
                return item;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(Guid guid)
        {
            try
            {
                var item = GetByGuid(guid);
                if (item == null)
                {
                    return false;
                }
                _context.Set<TEntity>().Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TEntity> GetAll()        
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity? GetByGuid(Guid guid)
        {
            var entity = _context.Set<TEntity>().Find(guid);
            _context.ChangeTracker.Clear();
            return entity;
        }

        public bool Update(TEntity item)
        {
            try
            {
                var guid = (Guid)typeof(TEntity).GetProperty("Id")!
                            .GetValue(item)!;
                var oldEntity = GetByGuid(guid);
                if (oldEntity == null)
                {
                    return false;
                }
                _context.Set<TEntity>().Update(item);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    /*        public TEntity? Create(TEntity item)
            {
                throw new NotImplementedException();
            }

            public bool Delete(Guid guid)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<TEntity> GetAll()
            {
                throw new NotImplementedException();
            }

            public TEntity? GetByGuid(Guid guid)
            {
                throw new NotImplementedException();
            }

            public bool Update(TEntity item)
            {
                throw new NotImplementedException();
            }
        }*/
}