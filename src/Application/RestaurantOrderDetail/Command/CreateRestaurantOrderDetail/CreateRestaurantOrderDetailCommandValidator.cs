using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateRestaurantOrderDetailCommandValidator : AbstractValidator<CreateRestaurantOrderDetailCommand>
{
    public CreateRestaurantOrderDetailCommandValidator()
    {
        RuleFor(v => v.RestaurantOrderID)
            .NotEmpty()
            .WithMessage("RestaurantOrderID is required.");
    }
}
