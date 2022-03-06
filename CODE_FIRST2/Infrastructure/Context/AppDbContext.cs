using CODE_FIRST2.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST2.Infrastructure.Context
{
    public  class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            Database.Connection.ConnectionString = @"Server=LAPTOP-ODR1NCVF\MSSQLSERVER1;Database=SecondDb_2;Integrated Security=true";
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
