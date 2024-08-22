using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllFoodQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? FoodName { get; set; }

    public string? FoodDescription { get; set; }

    public float? FoodPrice { get; set; }

    public float? FoodCategoryId { get; set; }

    public string? FoodCategoryName { get; set; }

    public bool? IsActive { get; set; }
}
