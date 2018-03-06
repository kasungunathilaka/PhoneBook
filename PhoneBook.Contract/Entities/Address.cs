﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Contract.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public Guid ContactDetailsId { get; set; }
    }
}
