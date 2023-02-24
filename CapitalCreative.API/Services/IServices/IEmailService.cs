using CapitalCreative.API.Models.Local;

namespace CapitalCreative.API.Services.IServices
{
    public interface IEmailService
    {
        Task<Result<string>> SendEmailAsync(EmailRequest email);
    }
}