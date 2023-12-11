namespace n5challenge.Infraestructure.UnitOfWork.Repositories
{
    public interface IBaseRepository<T>
        where T : class, new()
    {
        Task<IEnumerable<T>> List();
        Task Create(T entity);
        Task Edit(T entity);
        Task<bool> Exist(params object[] keyValues);
    }
}
