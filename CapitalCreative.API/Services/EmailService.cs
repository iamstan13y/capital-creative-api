﻿using CapitalCreative.API.Models.Local;
using CapitalCreative.API.Services.IServices;
using System.Net.Mail;
using System.Net;

namespace CapitalCreative.API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<Result<string>> SendEmailAsync(EmailRequest email)
        {
            MailMessage emailMessage = new()
            {
                Sender = new MailAddress(_configuration["EmailService:UserName"]!, _configuration["EmailService:DisplayName"]!),
                From = new MailAddress(email.From!, email.Name),
                IsBodyHtml = true,
                Subject = email.Subject,
                Body = email.Body,
                Priority = MailPriority.High,
            };

            emailMessage.To.Add(email.To!);

            using SmtpClient mailClient = new(_configuration["EmailService:Host"], int.Parse(_configuration["EmailService:Port"]!.ToString()));
            mailClient.Credentials = new NetworkCredential(_configuration["EmailService:Address"], _configuration["EmailService:Password"]);
            mailClient.EnableSsl = true;

            try
            {
                mailClient.Send(emailMessage);
                return Task.FromResult(new Result<string>("Email sent successfully!"));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<string>(false, ex.ToString()));
            }
        }
    }
}