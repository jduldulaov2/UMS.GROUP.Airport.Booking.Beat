using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.FoodCategory.Command.CreateFoodCategory;

public class CreateRestaurantOrderCommandValidator : AbstractValidator<CreateRestaurantOrderCommand>
{
    public CreateRestaurantOrderCommandValidator()
    {
        RuleFor(v => v.OrderReferrenceNumber)
            .NotEmpty()
            .WithMessage("OrderReferrenceNumber is required.");
    }
}
