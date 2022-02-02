using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isucorpTest.Models;
using isucorpTest.ViewModels;

namespace isucorpTest.Services
{
    public interface IContactService
    {
        List<Contact> GetContactsList();
        Contact GetContactDetailsById(long Id);
        ResponseModel SaveContact(Contact contactModel);
        ResponseModel DeleteContact(long Id);
    }
}
