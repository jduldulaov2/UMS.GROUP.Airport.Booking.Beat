using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllRestaurantTableQueryValidator : AbstractValidator<GetAllRestaurantTableByIdQuery>
{
    public GetAllRestaurantTableQueryValidator()
    {
        RuleFor(x => x.UniqueId)
            .NotEmpty().WithMessage("UniqueId is required.");
    }
}
