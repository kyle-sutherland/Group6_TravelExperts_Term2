namespace TravelExpertsData
{
    public static class BookingDetailManager
    {
        public static List<BookingDetail> GetAllBookingDetail(TravelExpertsContext db)
        {
            List<BookingDetail> bookingDetails = db.BookingDetails.ToList();
            return bookingDetails;
        }

        public static BookingDetail GetBookingDetailById(TravelExpertsContext db, int id)
        {
            BookingDetail bookingDetail = db.BookingDetails.Find(id);
            return bookingDetail;
        }

        /// <summary>
        /// Create a new Booking Detail, usually created with the Bookings table
        /// </summary>
        /// <param name="db">databa context</param>
        /// <param name="newBookingId">new booking ID</param>
        public static void CreateNewBookingDetail(TravelExpertsContext db, int newBookingId)
        {
            BookingDetail newbd = new BookingDetail();
            // booking id is needed for query
            newbd.BookingId = newBookingId;

            //FKs needed but just testing sample
            //since its technically not required for the workshop
            newbd.RegionId = "NA";
            newbd.ClassId = "BSN";
            newbd.FeeId = "BK";
            newbd.ProductSupplierId = 44;

            db.BookingDetails.Add(newbd);
            db.SaveChanges();
        }
    }
}
