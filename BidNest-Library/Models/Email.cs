using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidNest_Library.Models
{
    public class Email
    {
        public string recipientEmail {  get; set; }
        public string recipientName { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
