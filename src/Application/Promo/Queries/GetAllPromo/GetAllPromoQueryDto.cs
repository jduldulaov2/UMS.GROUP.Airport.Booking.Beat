using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllPromoQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? PromoCode { get; set; }

    public string? PromoName { get; set; }

    public string? PromoDescription { get; set; }

    public float? PromoPrice { get; set; }

    public bool? IsActive { get; set; }
}
