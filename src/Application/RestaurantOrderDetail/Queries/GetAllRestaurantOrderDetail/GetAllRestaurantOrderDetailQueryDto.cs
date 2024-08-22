using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllRestaurantOrderDetailQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public int? RestaurantOrderID { get; set; }

    public int? FoodID { get; set; }

    public float? OrderDetailFoodPrice { get; set; }

    public float? OrderQuantity { get; set; }

    public float? OrderTotalAmount { get; set; }

    public string? OrderSource { get; set; }

    public string? OrderDetailNotes { get; set; }

    public bool? IsActive { get; set; }
}
