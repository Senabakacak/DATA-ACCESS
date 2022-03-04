using CODE_FİRST1.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FİRST1.Inftastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        
            Database.Connection.ConnectionString = @"Server=LAPTOP-ODR1NCVF\MSSQLSERVER1;Database=FirstDb_1;Integrated Security=true";
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }

     
    }

}
