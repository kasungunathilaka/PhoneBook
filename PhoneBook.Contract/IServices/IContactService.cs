using PhoneBook.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Contract.IServices
{
    public interface IContactService
    {
        Task<List<ContactDTO>> GetAllContacts();
        ContactDTO GetContactById(string id);
        Task AddContact(ContactDTO addedContact);
        Task DeleteContact(string id);
        Task EditContact(string id, ContactDTO editedContact);
    }
}
