namespace LAOZ.CQRS.Core.Application.RepositoryInterfaces
{
    public interface ICommandRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
