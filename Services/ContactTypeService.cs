using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isucorpTest.Models;
using isucorpTest.ViewModels;
using isucorpTest.Services;

namespace isucorpTest.Services
{
    public class ContactTypeService : IContactTypeService
    {
        private readonly ISUCorpContext _context;
        public ContactTypeService(ISUCorpContext context)
        {
            _context = context;
        }

        public List<ContactType> GetContactTypeList()
        {
            List<ContactType> ContactTypeList;
            try
            {
                ContactTypeList = _context.Set<ContactType>().ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return ContactTypeList;
        }

        public ContactType GetContactTypeDetailsById(long Id)
        {
            ContactType contactType;
            try
            {
                contactType = _context.Find<ContactType>(Id);
            }
            catch
            {
                throw;
            }

            return contactType;
        }

        public ResponseModel AddContactType(ContactType item)
        {
            ResponseModel model = new();

            try
            {
                _context.Add<ContactType>(item);
                model.Message = "Added Succesfully a new contact type";
                model.IsSuccess = true;
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                model.IsSuccess = false;
                model.Message = "Error adding a new contact type (" + exception.Message + ")";
            }

            return model;
        }

        public ResponseModel UpdateContactType(ContactType item)
        {
            ResponseModel model = new();

            try
            {
                ContactType temp = _context.Find<ContactType>(item.Id);

                if(temp != null)
                {
                    temp.Description = item.Description;

                    _context.Update<ContactType>(temp);
                    _context.SaveChanges();

                    model.IsSuccess = true;
                    model.Message = "Contact Type modified succesfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Contact Type does not exists";
                }

            }
            catch (Exception exception)
            {
                model.IsSuccess = false;
                model.Message = "Error modifying contact type (" + exception.Message + ")";
            }

            return model;
        }

        public ResponseModel DeleteContactType(long Id)
        {
            ResponseModel model = new();

            try
            {
                ContactType contactTypeItem = _context.Find<ContactType>(Id);

                if(contactTypeItem != null)
                {
                    _context.Remove<ContactType>(contactTypeItem);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Contact Type deleted succesfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Contact Type does not exists";
                }
            }
            catch (Exception exception)
            {
                model.IsSuccess = false;
                model.Message = "Contact Type deleting error (" + exception.Message + ")";
            }

            return model;
        }
     }
}
