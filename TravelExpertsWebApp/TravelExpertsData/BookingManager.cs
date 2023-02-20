using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Create a new booking when customer is booking a package
        /// </summary>
        /// <param name="db">database context</param>
        /// <param name="newBooking">the new booking object</param>
        public static async void CreateNewBooking(TravelExpertsContext db, Booking newBooking)
        {
            db.Add(newBooking);
            await db.SaveChangesAsync();
        }
    }
}
