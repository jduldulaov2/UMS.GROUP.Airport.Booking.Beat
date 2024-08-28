using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllRestaurantUserLogQueryValidator : AbstractValidator<GetAllRestaurantUserLogByIdQuery>
{
    public GetAllRestaurantUserLogQueryValidator()
    {
        RuleFor(x => x.UniqueId)
            .NotEmpty().WithMessage("UniqueId is required.");
    }
}
