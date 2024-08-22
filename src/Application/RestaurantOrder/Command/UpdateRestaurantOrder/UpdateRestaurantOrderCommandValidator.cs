using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdateRestaurantOrderCommandValidator : AbstractValidator<UpdateRestaurantOrderCommand>
{
    public UpdateRestaurantOrderCommandValidator()
    {
        RuleFor(v => v.OrderReferrenceNumber)
            .NotEmpty()
            .WithMessage("OrderReferrenceNumber is required.");
    }
}
