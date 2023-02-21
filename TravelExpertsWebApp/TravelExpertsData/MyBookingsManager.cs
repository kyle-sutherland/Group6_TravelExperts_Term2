//Created by: Tim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class MyBookingsManager
    {
        //get booking details with relevent information from the packages and bookings tables
        public static List<MyBookingsDTO> GetMyBookingsByID(TravelExpertsContext db, int custId)
        {
            List<MyBookingsDTO> list = (from bd in db.BookingDetails
                                        join b in db.Bookings on bd.BookingId equals b.BookingId
                                        join p in db.Packages on b.PackageId equals p.PackageId
                                        where b.CustomerId == custId
                                        select new MyBookingsDTO
                                        {
                                            BookingNo = b.BookingNo,
                                            TravelerCount = b.TravelerCount,
                                            Destination = bd.Destination,
                                            PackageName = p.PkgName,
                                            PackagePrice = p.PkgBasePrice,
                                            BookingId = b.BookingId,
                                            PackageId = b.PackageId
                                        }).ToList();
            return list;
        }

        
        //Get customers info with relevent infromation from the bookings and packages tables
        public static List<Package> GetCustomersPackage(TravelExpertsContext db, int id = 0)
        {
            List<Package> packages = (from c in db.Customers
                                      join b in db.Bookings on c.CustomerId equals b.CustomerId
                                      join p in db.Packages on b.PackageId equals p.PackageId
                                      where b.CustomerId == id
                                      select new Package
                                      {
                                          PkgName = p.PkgName,
                                          PkgStartDate = Convert.ToDateTime(p.PkgStartDate),
                                          PkgEndDate = Convert.ToDateTime(p.PkgEndDate),
                                          PkgDesc = p.PkgDesc,
                                          PkgBasePrice = p.PkgBasePrice,
                                      }).ToList();
            return packages;
        }
    }
}
