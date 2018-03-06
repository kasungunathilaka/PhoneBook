﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Contract.DTOs
{
    public class ContactDTO
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string FacebookId { get; set; }
        public string ContactDetailsId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
    }
}
