namespace LAOZ.CQRS.Core.Application.RepositoryInterfaces
{
    public interface IQueryRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
