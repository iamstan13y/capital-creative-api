using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;

namespace CapitalCreative.API.Models.Repository
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        public QuoteRepository(AppDbContext context) : base(context)
        {
        }
    }
}