using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.FoodCategory.Command.UpdateFoodCategory;

public class UpdateRestaurantOrderDetailCommandValidator : AbstractValidator<UpdateRestaurantOrderDetailCommand>
{
    public UpdateRestaurantOrderDetailCommandValidator()
    {
        RuleFor(v => v.UniqueId)
            .NotEmpty()
            .WithMessage("UniqueId is required.");
    }
}
