using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class ProductDB
    {
        //Function accessed database via dbcontext. Returns object List of type Product
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            products.Clear();
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    var ps = db.Products;
                    foreach (Product p in ps)
                    {
                        products.Add(p);
                    }
                    return products;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Querying Database" + ex.Message);
                throw;
            }
        }
        //<summary>
        //creates a connection to database and retrieves a product entry based on product id
        //</summary>
        //<param name = "productcode" > the product code taked from user input</param>
        //<returns>Returns object of type Product</returns>
        public static Product GetProduct(int productId)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    var p = db.Products.Where(x => x.ProductId == productId).FirstOrDefault();
                    return p;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving from the database " + ex.GetType().ToString());
                throw;
            }
        }

        /// <summary>
        /// Adds a product from object of product type that is ceated by the calling object and passed as argument
        /// </summary>
        /// <param name="product">product to add</param>
        /// <returns></returns>
        public static void AddProduct(Product product)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    if (product != null)
                    {
                        db.Products.Add(product);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(product));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying database: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        ///Modifies a product from object  of product type that is created by the calling object and pass as argument
        /// </summary>
        /// <param name="product">product </param>
        /// <returns></returns>
        public static void ModifyProduct(Product product)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    if (product != null)
                    {
                        var p = db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                        if (p != null)
                        {
                            p.ProductId = product.ProductId;

                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying database: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        ///Deletes a product
        /// </summary>
        /// <returns></returns>
        public static void DeleteProduct(Product product)
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    if (product != null)
                    {
                        var p = db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                        if (p != null)
                        {
                            db.Products.Remove(p);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying database: " + ex.Message);
                throw;
            }
        }
    }
}
