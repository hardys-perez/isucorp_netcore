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
    public class ReservationController : ControllerBase
    {
        readonly public IReservationService _reservationService;
        public ReservationController(ReservationService service)
        {
            _reservationService = service;
        }

        [HttpGet]
        public IActionResult GetReservationList()
        {
            try
            {
                var reservationList = _reservationService.GetReservationList();
                if (reservationList == null)
                    return NotFound();
                return Ok(reservationList);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public IActionResult AddReservation(Reservation item)
        {
            try
            {
                var temp = _reservationService.AddReservation(item);
                return Ok(temp);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
