using Microsoft.EntityFrameworkCore;
using PhoneBook.Contract.DTOs;
using PhoneBook.Contract.Entities;
using PhoneBook.Contract.IServices;
using PhoneBook.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Business.Services
{
    public class ContactService : IContactService
    {
        private PhoneBookContext _dbConext;
        private Guid _customerGuid, _contactDetailsGuid;

        public ContactService(PhoneBookContext dbConext)
        {
            _dbConext = dbConext;
        }

        public async Task<List<ContactDTO>> GetAllContacts()
        {
            List<ContactDTO> contactDetails = new List<ContactDTO>();
            List<Customer> customers = await _dbConext.Customers.ToListAsync();

            foreach (var customer in customers)
            {
                if (customer != null)
                {
                    ContactDetails details = await _dbConext.ContactDetails.FirstOrDefaultAsync(d => d.CustomerId.Equals(customer.Id));
                    Address address = await _dbConext.Address.FirstOrDefaultAsync(a => a.ContactDetailsId.Equals(details.Id));

                    var contact = new ContactDTO
                    {
                        CustomerId = customer.Id.ToString(),
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Gender = customer.Gender,
                        Email = details.Email,
                        MobilePhone = details.MobilePhone,
                        HomePhone = details.HomePhone,
                        FacebookId = details.FacebookId,
                        ContactDetailsId = details.Id.ToString(),
                        Street = address.Street,
                        City = address.City,
                        Province = address.Province,
                        ZipCode = address.ZipCode
                    };
                    contactDetails.Add(contact);
                }               
            }
            return contactDetails;
        }

        public ContactDTO GetContactById(string id)
        {
            Customer customer = _dbConext.Customers.FirstOrDefault(c => c.Id.ToString().Equals(id));

            if (customer != null)
            {
                ContactDetails details = _dbConext.ContactDetails.FirstOrDefault(d => d.CustomerId.Equals(customer.Id));
                Address address = _dbConext.Address.FirstOrDefault(a => a.ContactDetailsId.Equals(details.Id));

                ContactDTO contact = new ContactDTO
                {
                    CustomerId = customer.Id.ToString(),
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Gender = customer.Gender,
                    Email = details.Email,
                    MobilePhone = details.MobilePhone,
                    HomePhone = details.HomePhone,
                    FacebookId = details.FacebookId,
                    ContactDetailsId = details.Id.ToString(),
                    Street = address.Street,
                    City = address.City,
                    Province = address.Province,
                    ZipCode = address.ZipCode
                };
                return contact;
            }
            return null;
        }

        public async Task AddContact(ContactDTO addedContact)
        {
            _customerGuid = Guid.NewGuid();
            _contactDetailsGuid = Guid.NewGuid();

            Customer customer = new Customer
            {
                Id = _customerGuid,
                FirstName = addedContact.FirstName,
                LastName = addedContact.LastName,
                Gender = addedContact.Gender
            };

            ContactDetails details = new ContactDetails
            {
                Id = _contactDetailsGuid,
                CustomerId = _customerGuid,
                Email = addedContact.Email,
                MobilePhone = addedContact.MobilePhone,
                HomePhone = addedContact.HomePhone,
                FacebookId = addedContact.FacebookId
            };

            Address address = new Address
            {
                ContactDetailsId = _contactDetailsGuid,
                City = addedContact.City,
                Province = addedContact.Province,
                Street = addedContact.Street,
                ZipCode = addedContact.ZipCode
            };

            await _dbConext.Customers.AddAsync(customer);
            await _dbConext.ContactDetails.AddAsync(details);
            await _dbConext.Address.AddAsync(address);
            await _dbConext.SaveChangesAsync();
        }

        public async Task DeleteContact(string id)
        {
            ContactDTO contact = GetContactById(id);
            Customer customer = _dbConext.Customers.FirstOrDefault(c => c.Id.ToString().Equals(contact.CustomerId));
            ContactDetails details = _dbConext.ContactDetails.FirstOrDefault(d => d.Id.ToString().Equals(contact.ContactDetailsId));
            Address address = _dbConext.Address.FirstOrDefault(a => a.ContactDetailsId.ToString().Equals(contact.ContactDetailsId));

            if (customer != null && details != null)
            {
                _dbConext.Customers.Remove(customer);
                _dbConext.ContactDetails.Remove(details);
                _dbConext.Address.Remove(address);
                await _dbConext.SaveChangesAsync();
            }            
        }

        public async Task EditContact(string id, ContactDTO editedContact)
        {
            ContactDTO contact = GetContactById(id);
            Customer customer = _dbConext.Customers.FirstOrDefault(c => c.Id.ToString().Equals(contact.CustomerId));
            ContactDetails details = _dbConext.ContactDetails.FirstOrDefault(d => d.Id.ToString().Equals(contact.ContactDetailsId));
            Address address = _dbConext.Address.FirstOrDefault(a => a.ContactDetailsId.ToString().Equals(contact.ContactDetailsId));

            if (customer != null && details != null)
            {
                customer.FirstName = editedContact.FirstName;
                customer.LastName = editedContact.LastName;
                customer.Gender = editedContact.Gender;

                details.Email = editedContact.Email;
                details.MobilePhone = editedContact.MobilePhone;
                details.HomePhone = editedContact.HomePhone;
                details.FacebookId = editedContact.FacebookId;

                address.Street = editedContact.Street;
                address.City = editedContact.City;
                address.Province = editedContact.Province;
                address.ZipCode = editedContact.ZipCode;

                _dbConext.Customers.Update(customer);
                _dbConext.ContactDetails.Update(details);
                _dbConext.Address.Update(address);
                await _dbConext.SaveChangesAsync();
            }
        }

    }
}
