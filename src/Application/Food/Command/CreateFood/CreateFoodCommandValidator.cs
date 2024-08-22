﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.FoodCategory.Command.CreateFoodCategory;

public class CreateFoodCommandValidator : AbstractValidator<CreateFoodCommand>
{
    public CreateFoodCommandValidator()
    {
        RuleFor(v => v.FoodName)
            .NotEmpty()
            .WithMessage("CategoryName is required.");

        RuleFor(v => v.FoodCategoryId)
            .NotEmpty()
            .WithMessage("FoodCategoryId is required.");
    }
}