using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class MyBookingsManager
    {
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

        //public static List<MyBookingsDTO> GetMyBookingsByID(TravelExpertsContext db, int custId)
        //{
        //    List<MyBookingsDTO> list = (from bd in db.BookingDetails
        //                                join b in db.Bookings on bd.BookingId equals b.BookingId
        //                                join p in db.Packages on b.PackageId equals p.PackageId into MyPackages
        //                                from mp in MyPackages.DefaultIfEmpty()
        //                                where b.CustomerId == custId && (mp == null || mp.PkgName == null)
        //                                select new MyBookingsDTO
        //                                {
        //                                    BookingNo = b.BookingNo,
        //                                    TravelerCount = b.TravelerCount,
        //                                    Destination = bd.Destination,
        //                                    PackageName = mp != null ? mp.PkgName : null,
        //                                    PackagePrice = mp != null ? mp.PkgBasePrice : null,
        //                                    BookingId = b.BookingId,
        //                                    PackageId = b.PackageId
        //                                }).ToList();
        //    return list;
        //}

        public static MyBookingsDTO GetMyBookingDetailsByBookingID(TravelExpertsContext db, int bookingId)
        {
            var details = (from b in db.Bookings
                           join p in db.Packages on b.PackageId equals p.PackageId
                           join bd in db.BookingDetails on b.BookingId equals bd.BookingId
                           join c in db.Classes on bd.ClassId equals c.ClassId
                           join f in db.Fees on bd.FeeId equals f.FeeId
                           join ps in db.ProductsSuppliers on bd.ProductSupplierId equals ps.ProductSupplierId
                           join prod in db.Products on ps.ProductId equals prod.ProductId
                           join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                           where b.BookingId == bookingId
                           select new MyBookingsDTO
                           {
                               BookingId = b.BookingId,
                               BookingDate = b.BookingDate,
                               BookingNo = b.BookingNo,
                               TravelerCount = b.TravelerCount,
                               ItineraryNo = bd.ItineraryNo,
                               TripStart = bd.TripStart,
                               TripEnd = bd.TripEnd,
                               Description = bd.Description,
                               Destination = bd.Destination,
                               BasePrice = bd.BasePrice,
                               RegionID = bd.RegionId,
                               ClassName = c.ClassName,
                               FeeName = f.FeeName,
                               FeeAmount = f.FeeAmt,
                               PackageName = p.PkgName,
                               PackagePrice = p.PkgBasePrice,
                               ProductName = prod.ProdName,
                               SupName = s.SupName
                           }).FirstOrDefault();
            return details;
        }

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
