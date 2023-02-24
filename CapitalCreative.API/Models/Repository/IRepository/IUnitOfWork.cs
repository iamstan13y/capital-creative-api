namespace CapitalCreative.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IProjectRepository Project { get; }
        IContactRepository Contact { get; }
        IQuoteRepository Quote { get; }
        void SaveChanges();
    }
}