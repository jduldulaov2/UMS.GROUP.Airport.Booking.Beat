using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllRestaurantOrderQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? OrderReferrenceNumber { get; set; }

    public string? OrderSource { get; set; }

    public int? OrderStatusID { get; set; }

    public int? OrderPaymentStatusID { get; set; }

    public float? OrderChargesAmount { get; set; }

    public float? OrderExtrasAmount { get; set; }

    public float? OrderPromoAmount { get; set; }

    public float? OrderTaxAmount { get; set; }

    public float? OrderPaymentSurchargeAmount { get; set; }

    public float? OrderTotalAmount { get; set; }

    public float? OrderPaidAmount { get; set; }

    public float? OrderOutstandingBalanceAmount { get; set; }

    public string? OrderNotes { get; set; }

    public int? RestaurantID { get; set; }

    public string? GuestID { get; set; }

    public string? GuestName { get; set; }

    public string? RestaurantName { get; set; }

    public bool? IsActive { get; set; }
}
