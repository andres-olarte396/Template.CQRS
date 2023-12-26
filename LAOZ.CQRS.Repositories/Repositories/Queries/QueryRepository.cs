using LAOZ.CQRS.Core.Application.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace LAOZ.CQRS.Infrastructure.Repositories.Queries
{
    public abstract class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public QueryRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
