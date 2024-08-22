using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class RestaurantBookingTable : BaseAuditableEntity
{
    public int? RestaurantBookingID{ get; set; }

    public int? RestaurantTableID { get; set; }

}
