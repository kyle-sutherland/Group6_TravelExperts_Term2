using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class MyBookingsDTO
    {
        // main details
        public string BookingNo { get; set; }

        [Display(Name = "Traveler Count")]
        public double? TravelerCount { get; set; }

        public string Destination { get; set; }

        [Display(Name = "Package Name")]
        public string PackageName { get; set; }

        [Display(Name = "Package Price")]
        public decimal PackagePrice { get; set; }

        // more details
        public int BookingId { get; set; }
        public DateTime? BookingDate { get; set; }
        public double? ItineraryNo { get; set; }
        public DateTime? TripStart { get; set; }
        public DateTime? TripEnd { get; set;}
        public string Description { get; set; }
        public decimal? BasePrice { get; set; }
        public string RegionID { get; set; }
        [Display(Name ="Class Name")]
        public string ClassName { get; set; }
        [Display(Name ="Fee Name")]
        public string FeeName { get; set; }
        [Display(Name ="Fee Amount")]
        public decimal? FeeAmount { get; set; }

        [Display(Name ="Included Product")]
        public string ProductName { get; set; }
        [Display(Name ="Product's Supplier")]
        public string SupName { get; set; }

        public int? PackageId { get; set; }

    }
}
