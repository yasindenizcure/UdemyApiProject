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

        public int BookingCount()
        {
            var context = new Context();
            var value = context.Bookings.Count();
            return value;
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

        public void BookingStatusChangeApproved2(int id)
        {
            var context = new Context();
            var value = context.Bookings.Find(id);
            value.Status = "Onaylandı";
            context.SaveChanges();

        }

        public void BookingStatusChangeCancel(int id)
        {
            var context = new Context();
            var value = context.Bookings.Find(id);
            value.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeWait(int id)
        {
            var context = new Context();
            var value = context.Bookings.Find(id);
            value.Status = "Müşteri Aranacak";
            context.SaveChanges();
        }

        public List<Booking> Last6Bookings()
        {
            var context = new Context();
            var values = context.Bookings.OrderByDescending(x => x.BookingId).Take(6).ToList();
            return values;
        }
    }
}
