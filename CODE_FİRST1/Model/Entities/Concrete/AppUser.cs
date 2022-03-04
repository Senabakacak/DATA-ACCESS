using CODE_FİRST1.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FİRST1.Model.Entities.Concrete
{
    [Table("AppUsers")]
    public  class AppUser:BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MinLength(11), MaxLength(12)]
        public string PhoneNumber { get; set; }

        
        public virtual List<Address> Addresses { get; set; }

       
    }
}
