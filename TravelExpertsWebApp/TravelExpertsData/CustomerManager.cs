//author tim
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class CustomerManager
    {
        public static Customer Authenticate(TravelExpertsContext db, string username, string password)
        {
            var customer = db.Customers.SingleOrDefault(cst => cst.Username == username
            && cst.Password == password);
            return customer;
        }

        public static void RegisterNewCustomer(TravelExpertsContext db, Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public static List<Customer> GetCustomers(TravelExpertsContext db)
        {
            List<Customer> customers = db.Customers.OrderBy(c => c.CustomerId).ToList();
            return customers;
        }

        public static void Update(TravelExpertsContext db, Customer customer)
        {
            db.Customers.Update(customer);
            db.SaveChanges();
        }

        //public static Customer Find(int id)
        //{
        //    var customer = DbContext.Find(s => s.CustomerId == id);
        //    return customer;
        //}
    }
}
