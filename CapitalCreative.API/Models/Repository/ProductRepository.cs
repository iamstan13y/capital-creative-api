using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;

namespace CapitalCreative.API.Models.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}