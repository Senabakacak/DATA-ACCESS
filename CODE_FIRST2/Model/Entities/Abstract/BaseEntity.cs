using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST2.Model.Entities.Abstract
{

    public enum Status { Active = 1, Modified = 2, Passive = 3 }
    public abstract  class BaseEntity<T>
    {
        public abstract T Id { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public Status Status { get; set; }

        
    }
}
