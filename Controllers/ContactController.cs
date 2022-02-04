using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isucorpTest.Services;
using isucorpTest.Models;

namespace isucorpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        readonly IContactService _contactService;
        public ContactController(IContactService service)
        {
            _contactService = service;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            try
            {
                var contacts = _contactService.GetContactsList();

                if (contacts == null)
                    return NotFound();
                return Ok(contacts);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetContactsById(long Id)
        {
            try
            {
                var contact = _contactService.GetContactDetailsById(Id);
                if (contact == null)
                    return NotFound();
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddContact(Contact contactModel)
        {
            try
            {
                var contact = _contactService.AddContact(contactModel);
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateContact(Contact contactModel)
        {
            try
            {
                var contact = _contactService.UpdateContact(contactModel);
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteContact(long Id)
        {
            try
            {
                var contact = _contactService.DeleteContact(Id);
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
