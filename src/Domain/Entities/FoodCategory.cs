using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class FoodCategory : BaseAuditableEntity
{
    public string? CategoryName { get; set; }

    public string? CategoryDescription { get; set; }

}
