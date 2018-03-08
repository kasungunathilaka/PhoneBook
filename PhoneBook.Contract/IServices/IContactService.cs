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
        Task<ContactDTO> GetContactById(string id);
        Task<List<ContactDTO>> SearchContactByName(string name);
        Task<List<ContactDTO>> SearchContactByNumber(string number);
        Task<List<string>> GetAllContactNames();
        Task AddContact(ContactDTO addedContact);
        Task DeleteContact(string id);
        Task EditContact(string id, ContactDTO editedContact);
    }
}
