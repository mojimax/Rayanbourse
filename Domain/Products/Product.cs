using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; } = string.Empty;
        public string ManufactureEmail { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
