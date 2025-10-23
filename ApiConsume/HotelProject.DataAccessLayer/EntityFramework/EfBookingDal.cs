using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System.Linq;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly Context _context;

        public EfBookingDal(Context context) : base(context)
        {
            _context = context;
        }

        public void BookingStatusChangeApproved(Booking booking)
        {
            var values = _context.Bookings.FirstOrDefault(x => x.BookingId == booking.BookingId);

            if (values == null)
            {
                throw new InvalidOperationException($"Booking with id {booking.BookingId} not found.");
            }

            values.Status = "Onaylandı";
            _context.SaveChanges();
        }
    }
}
