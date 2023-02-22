using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CapitalCreative.API.Models.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async new Task<Result<IEnumerable<Product>>> GetAllAsync()
        {
            var products = await _dbSet
                .Include(x => x.Category)
                .ToListAsync();

            return new Result<IEnumerable<Product>>(products);
        }

        public async new Task<Result<Product>> FindAsync(int id)
        {
            var product = await _dbSet
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null) return new Result<Product>(false, $"Product with id {id} not found.");
            
            return new Result<Product>(product);
        }
    }
}