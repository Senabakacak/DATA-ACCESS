using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FİRST1.Model.Entities.Abstract
{
    public enum Status { Active = 1, Modified = 2, Passive = 3 }

    public abstract  class BaseEntity
    {

        [Key] //Id= PK 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        

        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        [Column(TypeName = "datetime2", Order = 5)] 
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }
    }
}
