using System;
using System.Data.Entity;

namespace CustomerTansactions.Models
{
    public class CustomerTransactionContextInititalizer : CreateDatabaseIfNotExists<CustomerTransactionContext>
    {
        protected override void Seed(CustomerTransactionContext context)
        {
            base.Seed(context);
            var one = new Customer()
            {
                CustomerID = 1,
                EMail = "number1@gmail.com",
                Name = "No Transactions",
                Mobile = "012345678"
            };
            context.Customers.Add(one);
            var two = new Customer()
            {
                CustomerID = 2,
                EMail = "number2@gmail.com",
                Name = "One Transaction",
                Mobile = "012345678"
            };
            context.Customers.Add(two);
            var t1 = new Transaction()
            {
                ID = 1,
                Amount = 1234.56m,
                Currency = "USD",
                Date = DateTime.Now,
                Status = "Success",
                Customer = two
            };
            context.Transactions.Add(t1);
            var three = new Customer()
            {
                CustomerID = 3,
                EMail = "number3@gmail.com",
                Name = "Less than 5 Tranactions",
                Mobile = "012345678"
            };
            context.Customers.Add(three);
            var t21 = new Transaction()
            {
                ID = 2,
                Amount = 1234.56m,
                Currency = "USD",
                Date = DateTime.Now,
                Status = "Success",
                Customer = three
            };
            context.Transactions.Add(t21);
            var t22 = new Transaction()
            {
                ID = 3,
                Amount = 1234.56m,
                Currency = "USD",
                Date = DateTime.Now,
                Status = "Success",
                Customer = three
            };
            context.Transactions.Add(t22);
            var t23 = new Transaction()
            {
                ID = 4,
                Amount = 1234.56m,
                Currency = "USD",
                Date = DateTime.Now,
                Status = "Success",
                Customer = three
            };
            context.Transactions.Add(t23);
            var four = new Customer()
            {
                CustomerID = 4,
                EMail = "number4@gmail.com",
                Name = "More than 5 Tranactions",
                Mobile = "012345678"
            };
            context.Customers.Add(four);
            var t31 = new Transaction()
            {
                ID = 5,
                Amount = 1234.56m,
                Currency = "USD",
                Date = new DateTime(1982,2,2),
                Status = "Success",
                Customer = four
            };
            context.Transactions.Add(t31);
            var t32 = new Transaction()
            {
                ID = 6,
                Amount = 1234.56m,
                Currency = "USD",
                Date = new DateTime(1992, 2, 2),
                Status = "Success",
                Customer = four
            };
            context.Transactions.Add(t32);
            var t33 = new Transaction()
            {
                ID = 7,
                Amount = 1234.56m,
                Currency = "USD",
                Date = new DateTime(1972, 2, 2),
                Status = "Success",
                Customer = four
            };
            context.Transactions.Add(t33);
            var t34 = new Transaction()
            {
                ID = 8,
                Amount = 1234.56m,
                Currency = "USD",
                Date = new DateTime(1985, 2, 2),
                Status = "Success",
                Customer = four
            };
            context.Transactions.Add(t34);
            var t35 = new Transaction()
            {
                ID = 9,
                Amount = 1234.56m,
                Currency = "USD",
                Date = DateTime.Now,
                Status = "Success",
                Customer = four
            };
            context.Transactions.Add(t35);
            var t36 = new Transaction()
            {
                ID = 10,
                Amount = 1234.56m,
                Currency = "USD",
                Date = DateTime.Now,
                Status = "Success",
                Customer = four
            };
            context.Transactions.Add(t36);
            context.SaveChanges();
        }
    }

    public class CustomerTransactionContext : DbContext
    {
        public CustomerTransactionContext() : base()
        {
            Database.SetInitializer(new CustomerTransactionContextInititalizer());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}