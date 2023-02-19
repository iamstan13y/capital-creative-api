namespace CapitalCreative.API.Models.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISubscriptionRepository Subscription { get; }
        void SaveChanges();
    }
}