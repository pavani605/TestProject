using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
        [Required]
        public decimal MRP { get; set; }
    }
}
