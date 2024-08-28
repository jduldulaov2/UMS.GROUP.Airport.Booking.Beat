using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateRestaurantUserLogCommandValidator : AbstractValidator<CreateRestaurantUserLogCommand>
{
    public CreateRestaurantUserLogCommandValidator()
    {
        RuleFor(v => v.BookingNumber)
            .NotEmpty()
            .WithMessage("BookingNumber is required.");
    }
}
