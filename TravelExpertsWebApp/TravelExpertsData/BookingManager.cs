namespace TravelExpertsData
{
    public static class BookingManager
    {
        public static List<Booking> GetBookings(TravelExpertsContext db)
        {
            List<Booking> bookings = db.Bookings.ToList();
            return bookings;
        }

        public static Booking GetBookingById(TravelExpertsContext db, int id)
        {
            Booking booking = db.Bookings.Find(id);
            return booking;
        }

        public static void CreateNewBooking(TravelExpertsContext db, Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
        }


    }
}
