using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isucorpTest.Models
{
    [Table("contact")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name
        {
            get;
            set;
        }

        [StringLength(10, ErrorMessage = "Phone number can't be longer than 10 numbers")]
        public string PhoneNumber
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime BitrhDate
        {
            get;
            set;
        }

        public ContactType ContactType
        {
            get;
            set;
        }
    }
}