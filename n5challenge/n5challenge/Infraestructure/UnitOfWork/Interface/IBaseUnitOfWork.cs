namespace n5challenge.Infraestructure.UnitOfWork.Interface
{
    public interface IBaseUnitOfWork
    {
        Task Begin();
        Task Commit();
        Task Rollback();
    }
}
