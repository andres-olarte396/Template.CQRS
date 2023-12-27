using LAOZ.CQRS.Core.Application.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace LAOZ.CQRS.Infrastructure.Repositories.Commands
{
    public abstract class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public CommandRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
