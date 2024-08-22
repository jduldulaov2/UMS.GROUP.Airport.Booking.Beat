using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.FoodCategory.Command.CreateFoodCategory;

public class CreateRestaurantBookingCommandValidator : AbstractValidator<CreateRestaurantBookingCommand>
{
    public CreateRestaurantBookingCommandValidator()
    {
        RuleFor(v => v.BookingReferrenceNumber)
            .NotEmpty()
            .WithMessage("CategoryName is required.");
    }
}
