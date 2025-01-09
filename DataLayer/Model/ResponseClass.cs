using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class ResponseClass
    {
        [Key]
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
