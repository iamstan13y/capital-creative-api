namespace CapitalCreative.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        void SaveChanges();
    }
}