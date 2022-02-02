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
        [Route("[action]")]
        public IActionResult GetAllContacts()
        {
            try
            {
                var contacts = _contactService.GetContactsList();

                if (contacts == null)
                    return NotFound();
                return Ok(contacts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
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
        [Route("[action]")]
        public IActionResult SaveContact(Contact contactModel)
        {
            try
            {
                var contact = _contactService.SaveContact(contactModel);
                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]/Id")]
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
