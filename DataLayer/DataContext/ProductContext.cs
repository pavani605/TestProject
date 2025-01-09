using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataContext
{
    public class ProductContext:DbContext
    {
        protected readonly IConfiguration Configuration;
        public ProductContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("TestConnection"));
        }
        public DbSet<Product> Products { get; set; }    
        public DbSet<ResponseClass> responseClasses { get; set; }    
        public DbSet<Category> Categories { get; set; }    
    }
}
