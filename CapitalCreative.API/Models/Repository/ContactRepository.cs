using CapitalCreative.API.Models.Data;
using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Models.Repository.IRepository;
using CapitalCreative.API.Services.IServices;

namespace CapitalCreative.API.Models.Repository
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        
        public ContactRepository(AppDbContext context, IEmailService emailService, IConfiguration configuration) : base(context)
        {
            _emailService = emailService;
            _context = context;
            _configuration = configuration;
        }
        
        public async new Task<Result<Contact>> AddAsync(Contact contact)
        {
            await _dbSet.AddAsync(contact);
            await _context.SaveChangesAsync();
            
            await _emailService.SendEmailAsync(new EmailRequest
            {
                To = _configuration["EmailService:Address"],
                From = contact.Email,
                Name = contact.FullName,
                Body = contact.Message,
                Subject = $"New message from {contact.FullName}"
            });

            return new Result<Contact>(contact);
        }
    }
}