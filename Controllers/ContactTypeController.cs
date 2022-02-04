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
    public class ContactTypeController : ControllerBase
    {
        readonly IContactTypeService _contactTypeService;
        public ContactTypeController(IContactTypeService service)
        {
            _contactTypeService = service;
        }

        [HttpGet]
        public IActionResult GetContactTypeList()
        {
            try
            {
                var contactTypes = _contactTypeService.GetContactTypeList();

                if (contactTypes == null)
                    return NotFound();
                return Ok(contactTypes);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetContactTypeDetailsById(long Id)
        {
            try
            {
                var contactTypes = _contactTypeService.GetContactTypeDetailsById(Id);

                if (contactTypes == null)
                    return NotFound();
                return Ok(contactTypes);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult AddContactType(ContactType item)
        {
            try
            {
                var contactType = _contactTypeService.AddContactType(item);
                return Ok(contactType);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateContactType(ContactType item)
        {
            try
            {
                var contactType = _contactTypeService.UpdateContactType(item);
                return Ok(contactType);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteContactType(long Id)
        {
            try
            {
                var contactType = _contactTypeService.DeleteContactType(Id);
                return Ok(contactType);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
