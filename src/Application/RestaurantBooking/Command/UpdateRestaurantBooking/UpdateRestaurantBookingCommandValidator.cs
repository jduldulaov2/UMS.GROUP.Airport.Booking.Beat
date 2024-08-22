using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdateRestaurantBookingCommandValidator : AbstractValidator<UpdateRestaurantBookingCommand>
{
    public UpdateRestaurantBookingCommandValidator()
    {
        RuleFor(v => v.BookingReferrenceNumber)
            .NotEmpty()
            .WithMessage("BookingReferrenceNumber is required.");
    }
}
