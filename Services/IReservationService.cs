using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isucorpTest.Models;
using isucorpTest.ViewModels;

namespace isucorpTest.Services
{
    public interface IReservationService
    {
        List<Reservation> GetReservationList();
        Reservation GetReservationDetailsById(long Id);
        ResponseModel UpdateReservation(Reservation item);
        ResponseModel AddReservation(Reservation item);
        ResponseModel DeleteReservation(long Id);
    }
}
