using System;
using System.Runtime;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceStructure.Service.Product.API.Model
{
    public class Product
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Pic { get; set; }
        
    }
}
