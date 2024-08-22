using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Food.Queries.GetAllFoodById;

public class GetAllRestaurantOrderByIDQueryValidator : AbstractValidator<GetAllRestaurantOrderByIdQuery>
{
    public GetAllRestaurantOrderByIDQueryValidator()
    {
        RuleFor(x => x.UniqueId)
            .NotEmpty().WithMessage("UniqueId is required.");
    }
}
