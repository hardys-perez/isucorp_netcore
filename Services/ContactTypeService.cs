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

        public ResponseModel SaveContactType(ContactType contactTypeModel)
        {
            ResponseModel model = new();
            try
            {
                ContactType contactType = _context.Find<ContactType>(contactTypeModel.Id);
                
                if(model != null)
                {
                    contactType.Description = contactTypeModel.Description;

                    _context.Update<ContactType>(contactType);
                    model.Message = "Contact Type Updated Succesfully";
                }
                else
                {
                    _context.Add<ContactType>(contactType);
                    model.Message = "Contaact Type Added Succesfully";
                }

                model.IsSuccess = true;
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                model.IsSuccess = false;
                model.Message = exception.Message;
            }

            return model;
        }
        public ResponseModel DeleteContactType(long Id)
        {
            throw new NotImplementedException();
        }
     }
}
