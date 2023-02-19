using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;

namespace CapitalCreative.API.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ISubscriptionRepository Subscription { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            Role = new RoleRepository(context);
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}