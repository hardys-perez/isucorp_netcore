using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using isucorpTest.Models;

namespace isucorpTest.Models
{
    public class ISUCorpContext : DbContext
    {
        public ISUCorpContext(DbContextOptions options) : base(options) { }

        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactType> ContactTypes { get; set; }
        DbSet<Reservation> Reservations { get; set; }
    }
}
