using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService: IGenericService<Booking>
    {
        int TBookingCount();
        List<Booking> TLast6Bookings();
        void TBookingStatusChangeApproved(int id);
        void TBookingStatusChangeCancel(int id);
        void TBookingStatusChangeWait(int id);
    }
}
