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

        public static Customer GetCustomerById(TravelExpertsContext db, int customerId)
        {
            Customer? customer = db.Customers.Find(customerId);
            return customer;
        }

        public static void Update(TravelExpertsContext db, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerById(db, newCustomer.CustomerId);
            oldCustomer.CustFirstName= newCustomer.CustFirstName;
            oldCustomer.CustLastName= newCustomer.CustLastName;
            oldCustomer.CustAddress= newCustomer.CustAddress;
            oldCustomer.CustCity= newCustomer.CustCity;
            oldCustomer.CustProv = newCustomer.CustProv;
            oldCustomer.CustPostal= newCustomer.CustPostal;
            oldCustomer.CustCountry= newCustomer.CustCountry;
            oldCustomer.CustHomePhone= newCustomer.CustHomePhone;
            oldCustomer.CustBusPhone= newCustomer.CustBusPhone;
            oldCustomer.CustEmail= newCustomer.CustEmail;
            oldCustomer.Username= newCustomer.Username;
            oldCustomer.Password= newCustomer.Password;
            //db.Customers.Update(customer);
            db.SaveChanges();
        }
    }
}
