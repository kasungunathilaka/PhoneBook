using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBook.Contract.DTOs;
using PhoneBook.Contract.Entities;
using PhoneBook.Contract.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.WebAPI.Controllers
{
    [EnableCors("CrossPolicy")]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private IContactService _service;
        private ILogger<ContactsController> _logger;
        public ContactsController(IContactService service, ILogger<ContactsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            try
            {
                List<ContactDTO> contacts = new List<ContactDTO>();
                contacts = await _service.GetAllContacts();

                if (contacts.Count > 0)
                {
                    return Ok(contacts);                    
                }
                return NotFound("Could not found any contact.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while getting contacts: {ex.Message}");
            }
            return BadRequest("Could not found any contacts.");
        }

        [HttpGet("names")]
        public async Task<IActionResult> GetAllContactNames()
        {
            try
            {
                List<string> contactNames = new List<string>();
                contactNames = await _service.GetAllContactNames();

                if (contactNames.Count > 0)
                {
                    return Ok(contactNames);                    
                }
                return NotFound("Could not found any contact.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while getting contacts: {ex.Message}");
            }
            return BadRequest("Could not found any contacts.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            try
            {
                ContactDTO contact = new ContactDTO();
                contact = await _service.GetContactById(id);

                if (contact != null)
                {
                    return Ok(contact);
                }
                return NotFound("Could not found any contact.");                
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while getting contact: {ex.Message}");
            }
            return BadRequest("Could not found any contact.");
        }

        [HttpGet("search/{tag}")]
        public async Task<IActionResult> SearchContact(string tag)
        {
            try
            {
                List<ContactDTO> contacts = new List<ContactDTO>();
                List<ContactDTO> searchByName = await _service.SearchContactByName(tag);
                List<ContactDTO> searchByNumber = await _service.SearchContactByNumber(tag);

                if (searchByName != null)
                {
                    contacts.AddRange(searchByName);
                }
                if (searchByNumber != null)
                {
                    contacts.AddRange(searchByNumber);
                }

                if (contacts != null)
                {
                    return Ok(contacts);
                }
                return NotFound("Could not found any contact.");
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while getting contacts: {ex.Message}");
            }
            return BadRequest("Could not found any contacts.");
        }


        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody]ContactDTO addedContact)
        {
            try
            {
                if (addedContact != null)
                {
                    await _service.AddContact(addedContact);
                    return Ok("New contact Added.");
                }              
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while adding a new contact: {ex.Message}");
            }
            return BadRequest("Failed to add new contact.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditContact(string id, [FromBody]ContactDTO editedContact)
        {
            try
            {
                await _service.EditContact(id, editedContact);
                //GetContactById(id);
                return Ok("Contact Edited.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while editing the contact: {ex.Message}");
            }
            return BadRequest("Failed to edit the contact.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            try
            {
                await _service.DeleteContact(id);
                return Ok("Contact Deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while deleting the contact: {ex.Message}");
            }
            return BadRequest("Failed to delete the contact.");
        }
    }
}
