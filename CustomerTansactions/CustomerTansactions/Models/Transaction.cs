﻿using System;

namespace CustomerTransactions.Models
{
    public class Transaction
    {
        public long ID { get; set; }
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }

        public Customer Customer { get; set; }
    }
}