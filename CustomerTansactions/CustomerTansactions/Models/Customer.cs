using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerTansactions.Models
{
    public class Customer
    {
        [Key, Required]
        public int CustomerID { get; set; }
        [Key, Required, StringLength(25)]
        public string EMail { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Mobile { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}