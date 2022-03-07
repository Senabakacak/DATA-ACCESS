using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_FIRST_LABS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindEntities db = new NorthwindEntities();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                LastName=x.LastName,
                Age= SqlFunctions.DateDiff("Year", x.BirthDate, DateTime.Now)
            }).ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = SqlFunctions.DateDiff("Year", x.BirthDate, DateTime.Now)
            })
            .Where(x => x.Age > 60)
            .OrderByDescending(x => x.Age)
            .ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            dataGridView1.DataSource = db.Products.GroupBy(x => x.Category.CategoryName)
                                                  .Select(x => new
                                                  {
                                                      CategoryName = x.Key,
                                                      Stock = x.Sum(y => y.UnitsInStock)
                                                  })
                                                  .OrderByDescending(x => x.Stock)
                                                  .ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.GroupBy(x => x.Supplier.CompanyName)
                                                     .Select(x => new
                                                     {
                                                         CompanyName = x.Key,
                                                         Amount = x.Count()
                                                     })
                                                     .OrderByDescending(x => x.Amount)
                                                     .ToList();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Employees.Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.TitleOfCourtesy,
                Age = SqlFunctions.DateDiff("Year", x.BirthDate, DateTime.Now)
            })
            .Where(x => x.Title.Contains("Mr.") || (x.Age >= 50 && x.Age <= 60))
            .OrderByDescending(x => x.Age)
            .ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = db.Products
                .Join(db.Order_Details, p => p.ProductID, od => od.ProductID, (p, od) => new { p, od })
                .GroupBy(x => x.p.ProductName)
                .Select(z => new
                {
                    ProdcutName = z.Key,
                    Amount = z.Sum(y => y.od.Quantity),
                    Income = z.Sum(y => y.od.Quantity * y.od.UnitPrice)
                })
                .OrderByDescending(x => x.Income)
                .ToList();
        }

       
    }
}
