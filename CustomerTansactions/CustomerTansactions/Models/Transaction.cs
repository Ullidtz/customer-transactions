using System;

namespace CustomerTansactions.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }

        public Customer Customer { get; set; }
    }
}