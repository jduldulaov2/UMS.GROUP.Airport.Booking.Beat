using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllDraftCartItemsQueryDtoByCode
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? BookingReservationId { get; set; }

    public int? FoodId { get; set; }

    public string? FoodName { get; set; }

    public string? FoodDescription { get; set; }

    public float? CurrentPrice { get; set; }

    public float? CurrentQuantity { get; set; }

    public float? CurrentTotal { get; set; }

    public bool? IsActive { get; set; }
}
