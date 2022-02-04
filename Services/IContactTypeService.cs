using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isucorpTest.Models;
using isucorpTest.ViewModels;

namespace isucorpTest.Services
{
    public interface IContactTypeService
    {
        List<ContactType> GetContactTypeList();
        ContactType GetContactTypeDetailsById(long Id);
        ResponseModel UpdateContactType(ContactType item);
        ResponseModel AddContactType(ContactType item);
        ResponseModel DeleteContactType(long Id);
    }
}
