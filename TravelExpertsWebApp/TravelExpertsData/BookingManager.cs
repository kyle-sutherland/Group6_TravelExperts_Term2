//Created by: Kyle and Tim
namespace TravelExpertsData
{
    public class BookingManager
    {
        //get a list of bookings
        public static List<Booking> GetBookings(TravelExpertsContext db)
        {
            List<Booking> bookings = db.Bookings.ToList();
            return bookings;
        }

        //get a specific booking by id
        public static Booking GetBookingById(TravelExpertsContext db, int id)
        {
            Booking booking = db.Bookings.Find(id);
            return booking;
        }

        //add a new booking to the database
        public static void CreateNewBooking(TravelExpertsContext db, Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
        }
    }
}
