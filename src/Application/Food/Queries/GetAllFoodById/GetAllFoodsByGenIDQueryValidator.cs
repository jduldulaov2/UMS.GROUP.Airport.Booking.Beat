﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Food.Queries.GetAllFoodById;

public class GetAllFoodsByGenIDQueryValidator : AbstractValidator<GetAllFoodByIdQuery>
{
    public GetAllFoodsByGenIDQueryValidator()
    {
        RuleFor(x => x.UniqueId)
            .NotEmpty().WithMessage("UniqueId is required.");
    }
}
