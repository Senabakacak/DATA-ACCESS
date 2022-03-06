using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_FIRST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindEntities1 db = new NorthwindEntities1();
        
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Categories.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.UnitPrice,
                x.UnitsInStock,
                x.CategoryID
            }).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.Where(x => x.UnitsInStock == 10 ||
                                                              x.UnitsInStock == 20)
                                                  .ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Category category = db.Categories.First(x => x.CategoryID > 20); 

                MessageBox.Show($"Id: {category.CategoryID}\nName: {category.CategoryName}");
            }
            catch (Exception)
            {
                MessageBox.Show("Aradığınız kategori bulunmamaktadır..!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Category category = db.Categories.FirstOrDefault(x => x.CategoryID > 27);

            if (category == null)
                MessageBox.Show("Aradığınız kategori bulunmamaktadır..!");
            else
                MessageBox.Show($"Id: {category.CategoryID}\nName: {category.CategoryName}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Category category = db.Categories.Find(50);

            if (category == null)
                MessageBox.Show("Aradığınız kategori bulunmamaktadır..!");
            else
                MessageBox.Show($"Id: {category.CategoryID}\nName: {category.CategoryName}");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Employees.Take(5).ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.OrderByDescending(x => x.UnitPrice)
                                                  .Skip(5)
                                                  .Take(5)
                                                  .ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Employees.Where(x => x.FirstName.Contains("a"))
                                                   .OrderBy(x => x.FirstName)
                                                   .Select(x => new
                                                   {
                                                       x.EmployeeID,
                                                       x.FirstName,
                                                       x.LastName,
                                                       x.Title
                                                   }).ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Employees.Where(x => x.FirstName.StartsWith("S"))
                                                  .Select(x => new
                                                  {
                                                      x.EmployeeID,
                                                      x.FirstName,
                                                      x.LastName,
                                                      x.Title
                                                  }).ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.Where(x => x.ProductName.EndsWith("e"))
                                                 .OrderBy(x => x.ProductName)
                                                 .Select(x => new
                                                 {
                                                     x.ProductID,
                                                     x.ProductName,
                                                     x.UnitPrice,
                                                     x.UnitsInStock
                                                 }).ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bool result = db.Categories.Any(x => x.CategoryName == "SeaFood");

            if (result)
                MessageBox.Show("Aradığınız kategori bulunmaktadır..!");
            else
                MessageBox.Show("Aradığınız kategori bulunmamaktadır..!");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int productCount = db.Products.Count();
            MessageBox.Show($"Count of Product: {productCount}");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int? stock = db.Products.Sum(x => x.UnitsInStock);

            MessageBox.Show($"Stock Condition: {stock}");

        }
    }
}

