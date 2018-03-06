using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Contract.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public ContactDetails ContactDetails { get; set; }
    }
}
