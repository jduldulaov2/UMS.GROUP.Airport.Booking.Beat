using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class Promo : BaseAuditableEntity
{
    public string? PromoCode { get; set; }

    public string? PromoName { get; set; }

    public string? PromoDescription { get; set; }

    public float? PromoPrice { get; set; }

}

