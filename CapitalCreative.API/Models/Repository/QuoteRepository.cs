using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using CapitalCreative.API.Services.IServices;

namespace CapitalCreative.API.Models.Repository
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public QuoteRepository(AppDbContext context, IEmailService emailService, IConfiguration configuration) : base(context)
        {
            _emailService = emailService;
            _configuration = configuration;
            _context = context;
        }

        public async new Task<Result<Quote>> AddAsync(Quote quote)
        {
            await _dbSet.AddAsync(quote);
            await _context.SaveChangesAsync();

            await _emailService.SendEmailAsync(new EmailRequest
            {
                To = _configuration["EmailService:Address"],
                From = quote.Email,
                Name = quote.FullName,
                Body = $"You've received a new quote request from {quote.FullName}. Log into your portal to check it out.",
                Subject = $"New quote request from {quote.FullName}"
            });

            return new Result<Quote>(quote);
        }
    }
}