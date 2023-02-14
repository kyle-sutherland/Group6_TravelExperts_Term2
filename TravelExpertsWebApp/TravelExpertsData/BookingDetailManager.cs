namespace TravelExpertsData
{
    internal class BookingDetailManager
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

        public static void CreateNewBookingDetail(TravelExpertsContext db, BookingDetail bookingDetail)
        {
            db.BookingDetails.Add(bookingDetail);
            db.SaveChanges();
        }

    }
}
