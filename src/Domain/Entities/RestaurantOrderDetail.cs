using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class RestaurantOrderDetail : BaseAuditableEntity
{
    public int? RestaurantOrderID { get; set; }

    public int? FoodID { get; set; }

    public string? OrderSource { get; set; }

    public float? OrderDetailFoodPrice { get; set; }

    public string? OrderDetailNotes { get; set; }

}
