using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isucorpTest.Models;
using isucorpTest.ViewModels;
using isucorpTest.Services;

namespace isucorpTest.Services
{
    public class ContactService : IContactService
    {
        private readonly ISUCorpContext _context;
        public ContactService(ISUCorpContext context)
        {
            _context = context;
        }

        public List<Contact> GetContactsList()
        {
            List<Contact> contactsList;
            try
            {
                contactsList = _context.Set<Contact>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contactsList;
        }
        public Contact GetContactDetailsById(long Id)
        {
            Contact contact;
            try
            {
                contact = _context.Find<Contact>(Id);
            }
            catch (Exception)
            {
                throw;
            }
            return contact;
        }

        public ResponseModel AddContact(Contact item)
        {
            ResponseModel model = new();

            try
            {
                _context.Add<Contact>(item);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.Message = "Contac added succesfully";
            }
            catch (Exception exception)
            {
                model.IsSuccess = false;
                model.Message = "Error adding a new contact (" + exception.Message + ")";
            }

            return model;
        }

        public ResponseModel UpdateContact(Contact item)
        {
            ResponseModel model = new();

            try
            {
                Contact temp = _context.Find<Contact>(item.Id);

                if (temp != null)
                {
                    temp.Name = item.Name;
                    temp.PhoneNumber = item.PhoneNumber;
                    temp.BitrhDate = item.BitrhDate;
                    temp.Reservations = item.Reservations;
                    temp.ContactTypeId = item.ContactTypeId;

                    _context.Add<Contact>(temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Contact updated successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Contact does not exists";
                }
            }
            catch(Exception exception)
            {
                model.IsSuccess = false;
                model.Message = "Contact updated error (" + exception.Message + ")";
            }

            return model;
        }

        public ResponseModel DeleteContact(long Id)
        {
            ResponseModel model = new();

            try
            {
                Contact contact = GetContactDetailsById(Id);
                if(contact != null)
                {
                    _context.Remove<Contact>(contact);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Contact deleted succesfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Contact does not exist";
                }
            }
            catch (Exception exception)
            {
                model.IsSuccess = false;
                model.Message = exception.Message;
            }

            return model;
        }
    }
}
