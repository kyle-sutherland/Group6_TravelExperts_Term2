using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class ProductSupplierInfo
    {
        public int ProductSupplierId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }

        public string? ProdName { get; set; }
        public string? SupName { get; set; }

        public Product? Product { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
