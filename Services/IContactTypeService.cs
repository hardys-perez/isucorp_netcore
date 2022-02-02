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
        ResponseModel SaveContactType(ContactType contactTypeModel);
        ResponseModel DeleteContactType(long Id);

    }
}
