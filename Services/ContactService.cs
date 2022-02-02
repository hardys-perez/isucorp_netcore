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

        public ResponseModel SaveContact(Contact contactModel)
        {
            ResponseModel model = new ();

            try
            {
                Contact _temp = GetContactDetailsById(contactModel.Id);

                if (_temp != null)
                {
                    _temp.Name = contactModel.Name;
                    _temp.BitrhDate = contactModel.BitrhDate;
                    _temp.ContactType = contactModel.ContactType;

                    _context.Update<Contact>(_temp);
                    model.Message = "Contact Updated Successfully";
                }
                else
                {
                    _context.Add<Contact>(contactModel);
                    model.Message = "Contact Added Successfully";
                }

                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception exception)
            {
                model.IsSuccess = false;
                model.Message = exception.Message;
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
