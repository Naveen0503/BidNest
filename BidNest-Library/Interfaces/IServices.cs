using BidNest_Library.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidNest_Library.Interfaces
{
    public interface IServices
    {
        Task<string> SendEmailAsync(Email email);
        Task<byte[]> SaveImageDataAsync(IFormFile file);
    }
}
