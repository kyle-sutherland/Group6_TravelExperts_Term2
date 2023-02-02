using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class ProductDB
    {
        public static List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                products.AddRange(db.Products);
            }
            return products;
        }
    }
}
