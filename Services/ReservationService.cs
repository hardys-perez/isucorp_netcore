using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isucorpTest.Models;
using isucorpTest.Services;
using isucorpTest.ViewModels;

namespace isucorpTest.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ISUCorpContext _context;
        public ReservationService(ISUCorpContext context)
        {
            _context = context;
        }

        public ResponseModel AddReservation(Reservation item)
        {
            ResponseModel model = new();

            try
            {
                _context.Add<Reservation>(item);
                model.Message = "Added Succesfully a new reservation";
                model.IsSuccess = true;
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                model.IsSuccess = false;
                model.Message = "Error adding a new reservation (" + exception.Message + ")";
            }

            return model;
        }

        public ResponseModel DeleteReservation(long Id)
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationDetailsById(long Id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetReservationList()
        {
            List<Reservation> reservationList;
            try
            {
                reservationList = _context.Set<Reservation>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return reservationList;
        }

        public ResponseModel UpdateReservation(Reservation item)
        {
            throw new NotImplementedException();
        }
    }
}
