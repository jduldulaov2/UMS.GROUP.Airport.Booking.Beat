using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class Food : BaseAuditableEntity
{
    public string? FoodName { get; set; }

    public string? FoodDescription { get; set; }

    public float? FoodPrice { get; set; }

}
