using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class RestaurantUserLog : BaseAuditableEntity
{
    public string? BookingNumber { get; set; }

    public string? FullName { get; set; }

    public string? BookingLogs { get; set; }

    public string? BookingStatusId { get; set; }
}
