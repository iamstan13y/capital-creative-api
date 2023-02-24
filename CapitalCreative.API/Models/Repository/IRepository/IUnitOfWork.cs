namespace CapitalCreative.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProjectRepository Project { get; }
        IContactRepository Contact { get; }
        void SaveChanges();
    }
}