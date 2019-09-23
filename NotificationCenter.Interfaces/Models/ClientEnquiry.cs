using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationCenter.Interfaces.Enums;

namespace NotificationCenter.Interfaces.Models
{
    public class ClientEnquiry
    {
        public string IncomingNumber { get; set; }

        public long ClientId { get; set; }

        public EnquiryType EnquiryType { get; set; }

        public DateTime CreationDate { get; set; }

        public EnquiryState State { get; set; }
    }
}
