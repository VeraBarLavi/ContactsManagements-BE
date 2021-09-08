using System;
using Contacts.Core;
using Contacts.DB;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ContactsController : ControllerBase
    {
        private IContactsServices _contactsServices;

        public ContactsController(IContactsServices contactsServices)
        {
            _contactsServices = contactsServices;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(_contactsServices.GetContacts());
        }

        [HttpGet("{id}", Name ="GetContact")]
        public IActionResult GetContact(string id)
        {
            return Ok(_contactsServices.GetContact(id));
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            try
            {
                var newContact = _contactsServices.CreateContact(contact);
                return CreatedAtRoute(nameof(GetContact), new { newContact.ID }, newContact);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteContact(Contact contact)
        {
            _contactsServices.DeleteContact(contact);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditContact(Contact contact)
        {
            return Ok(_contactsServices.EditContact(contact));
        }
    }
}
