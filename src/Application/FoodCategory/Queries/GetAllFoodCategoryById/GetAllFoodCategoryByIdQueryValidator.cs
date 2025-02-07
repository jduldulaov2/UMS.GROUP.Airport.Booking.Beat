﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllFoodByIdQueryValidator : AbstractValidator<GetAllFoodCategoryByIdQuery>
{
    public GetAllFoodByIdQueryValidator()
    {
        RuleFor(x => x.UniqueId)
            .NotEmpty().WithMessage("UniqueId is required.");
    }
}
