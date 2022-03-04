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
    [Table("Addresses")]
    public class Address:BaseEntity
    {
        [Required]
        public string Region { get; set; }

        [Required]
        public string PostCode { get; set; }

        [ForeignKey("AppUser")]
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
