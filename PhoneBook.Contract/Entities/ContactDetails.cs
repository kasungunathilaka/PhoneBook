﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Contract.Entities
{
    public class ContactDetails
    {
        public Guid Id { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string FacebookId { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
    }
}
