using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class DB_Utils
    {
        //Function to get data for all Products. Returns object List of type Product
        public static List<ProductInfo> GetSuppliersByProducts()
        {
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    var query = (from product in db.Products
                                 join productSupplier in db.ProductsSuppliers
                                 on product.ProductId equals productSupplier.ProductId
                                 join supplier in db.Suppliers
                                 on productSupplier.SupplierId equals supplier.SupplierId
                                 select new ProductInfo
                                 {
                                     ProductId = product.ProductId,
                                     ProdName = product.ProdName,
                                     SupName = supplier.SupName
                                 }).Distinct();
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Querying Database" + ex.Message);
                throw;
            }
        }

        

        /// <summary>
        /// Function to get data from joined table Product-Suppliers
        /// </summary>
        /// <returns> List of type ProductSupplierInfo. This is a custom type I made for the purpose of containing and passing
        /// the LINQ query results which, since it is a joing statement with a bridge table would otherwise produce an anonymous type.
        /// </returns>
        public static List<ProductSupplierInfo> GetAllProductsSupplier()
        {
            //List<ProductSupplierInfo> productsSupplierList = new List<ProductSupplierInfo>();
            try
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // grab data from db
                    var ps_query = (from ps in db.ProductsSuppliers
                                   join p in db.Products on ps.ProductId equals p.ProductId
                                   join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                                   orderby s.SupName
                                   select new ProductSupplierInfo
                                   {
                                       ProductSupplierId = ps.ProductSupplierId,
                                       ProductId = p.ProductId,
                                       ProdName = p.ProdName,
                                       SupplierId = s.SupplierId,
                                       SupName = s.SupName
                                   }).ToList();
                    return ps_query;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Querying Database" + ex.Message);
                throw;
            }
        }

        ///<summary>
        /// creates a connection to database and retrieves a product entry based on product id
        /// </summary>
        /// <param name = "productcode" > the product code taked from user input</param>
        ///<returns>Returns object of type Product</returns>
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
