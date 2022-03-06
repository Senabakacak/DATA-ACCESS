using CODE_FIRST2.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST2.Model.Entities.Concrete
{
    public  class Category:BaseEntity<string>
    {
       public override string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual List<Product>Products { get; set; }

    }
}
