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
        public async Task<IActionResult> GetAllContactsAsync()
        {
            try
            {
                List<ContactDTO> contacts = new List<ContactDTO>();
                contacts = await _service.GetAllContacts();

                if (contacts == null)
                {
                    return NotFound("Could not found any contact.");
                }
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while getting contacts: {ex.Message}");
            }
            return BadRequest("Could not found any contacts.");
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(string id)
        {
            try
            {
                ContactDTO contact = new ContactDTO();
                contact = _service.GetContactById(id);

                if (contact == null)
                {
                    return NotFound("Could not found any contact.");
                }
                return Ok(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred while getting contact: {ex.Message}");
            }
            return BadRequest("Could not found any contact.");
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody]ContactDTO addedContact)
        {
            try
            {
                await _service.AddContact(addedContact);
                return Ok("New contact Added.");
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
