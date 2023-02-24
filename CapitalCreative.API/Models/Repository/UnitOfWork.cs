using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using CapitalCreative.API.Services.IServices;

namespace CapitalCreative.API.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProjectRepository Project { get; private set; }
        public IContactRepository Contact { get; private set; }

        public UnitOfWork(AppDbContext context, IEmailService emailService, IConfiguration configuration)
        {
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            Project = new ProjectRepository(context);
            Contact = new ContactRepository(context, emailService, configuration);
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}