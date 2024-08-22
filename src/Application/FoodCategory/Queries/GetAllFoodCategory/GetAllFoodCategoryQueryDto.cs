using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.FoodCategory.Queries.GetAllFoodCategory;

public class GetAllFoodCategoryQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryDescription { get; set; }

    public bool? IsActive { get; set; }
}
