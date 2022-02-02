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

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveContactType(ContactType contactTypeModel)
        {
            try
            {
                var contactType = _contactTypeService.SaveContactType(contactTypeModel);
                return Ok(contactType);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
