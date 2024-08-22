using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Food.Queries.GetAllFoodById;

public class GetAllRestaurantOrderDetailByIDQueryValidator : AbstractValidator<GetAllRestaurantOrderDetailByIdQuery>
{
    public GetAllRestaurantOrderDetailByIDQueryValidator()
    {
        RuleFor(x => x.UniqueId)
            .NotEmpty().WithMessage("UniqueId is required.");
    }
}
