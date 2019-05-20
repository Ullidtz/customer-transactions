using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerTansactions.Models
{
    public class Customer
    {
        [Key, Required]
        public long CustomerID { get; set; }
        [Index("EMail_Index", IsUnique = true), Required, StringLength(25)]
        public string EMail { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Mobile { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}