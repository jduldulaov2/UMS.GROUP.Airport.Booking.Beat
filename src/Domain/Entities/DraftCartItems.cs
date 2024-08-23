using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;

public class DraftCartItems : BaseAuditableEntity
{
    public int? BookingReservationId { get; set; }

    public int? FoodId { get; set; }

}
