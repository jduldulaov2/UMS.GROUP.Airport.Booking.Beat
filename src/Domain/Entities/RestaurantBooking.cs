﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class RestaurantBooking : BaseAuditableEntity
{
    public string? BookingReferrenceNumber { get; set; }

    public string? BookingFromDate { get; set; }

    public string? BookingToDate { get; set; }

    public string? BookingSource { get; set; }

    public DateTime? BookingEstimatedArrivalTime { get; set; }

    public DateTime? BookingEstimatedDepartureTime { get; set; }

    public int? BookingStatusID { get; set;}

    public int? BookingPaymentStatusID { get; set; }

    public float? BookingChargesAmount { get; set; }

    public float? BookingExtrasAmount{ get; set; }

    public float? BookingPromoAmount { get; set; }

    public float? BookingTaxAmount { get; set; }

    public float? BookingPaymentSurchargeAmount { get; set; }

    public float? BookingTotalAmount { get; set; }

    public float? BookingPaidAmount { get; set; }

    public float? BookingOutstandingBalanceAmount { get; set; }

    public string? BookingNotes { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TableIDOther { get; set; }

    public int? RestaurantID { get; set; }

    public int? GuestID { get; set; }

    public int? TableID { get; set; }

    public int? OrderID { get; set; }
}
