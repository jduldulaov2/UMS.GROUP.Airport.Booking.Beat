using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.FoodCategory.Command.UpdateFoodCategory;

public class UpdateFoodCommandValidator : AbstractValidator<UpdateFoodCommand>
{
    public UpdateFoodCommandValidator()
    {
        RuleFor(v => v.FoodName)
            .NotEmpty()
            .WithMessage("FoodName is required.");

        RuleFor(v => v.FoodCategoryId)
            .NotEmpty()
            .WithMessage("FoodCategoryId is required.");
    }
}
