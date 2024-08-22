using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class RestaurantPayment : BaseAuditableEntity
{
    public string? PaymentReferrenceNumber { get; set; }

    public string? PaymentSource { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int? BookingTableID { get; set; }

    public int? BookingOrderID { get; set; }

    public float? PaymentAmountToBePaid { get; set; }

    public float? PaymentActualAmount { get; set; }

    public float? PaymentRunningBalance { get; set; }

    public float? ProcessedBy { get; set; }

    public int? RestaurantID { get; set; }

    public int? GuestID { get; set; }

}
