using BidNest_Library.Interfaces;
using BidNest_Library.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BidNest_Library.Helpers
{
     public class Services : IServices
     {
        private readonly EmailConfiguration _emailConfig;
        public Services(IOptions<EmailConfiguration> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task<byte[]> SaveImageDataAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] data = memoryStream.ToArray();
                return data;
            }
        }

        public async Task<string> SendEmailAsync(Email email)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_emailConfig.From));
            message.To.Add(MailboxAddress.Parse(email.recipientEmail));
            message.Subject = email.subject;
            message.Body = new TextPart("html")
            {
                Text = $"{email.body}"
            };

            var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(_emailConfig.Server, _emailConfig.Port, true);
                 client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(new NetworkCredential(_emailConfig.From, _emailConfig.Password));
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return "Email Sent Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
