using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isucorpTest.Models
{
    [Table("reservation")]
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { 
            get; 
            set; 
        }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(300, ErrorMessage = "Description can't be longer than 300 characters")]
        public string Descripction 
        { 
            get; 
            set; 
        }

        public Contact Contact
        {
            get;
            set;
        }
    }
}