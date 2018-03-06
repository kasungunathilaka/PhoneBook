using Microsoft.EntityFrameworkCore;
using PhoneBook.Contract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Persistence
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(a => a.ContactDetails)
                .WithOne(b => b.Customer)
                .HasForeignKey<ContactDetails>(b => b.CustomerId);

            modelBuilder.Entity<ContactDetails>()
                .HasOne(a => a.Address)
                .WithOne(b => b.ContactDetails)
                .HasForeignKey<Address>(b => b.ContactDetailsId);
        }
    }
}
