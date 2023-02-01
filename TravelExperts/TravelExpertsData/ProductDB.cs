using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    internal class ProductDB
    {
        public static void GetAllProducts()
        {
            var products = new List<Product>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                products.AddRange(db.Products);
            }
        }
    }
}
