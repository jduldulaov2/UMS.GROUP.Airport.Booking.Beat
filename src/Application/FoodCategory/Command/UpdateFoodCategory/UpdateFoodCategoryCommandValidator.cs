using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.FoodCategory.Command.UpdateFoodCategory;

public class UpdateFoodCategoryCommandValidator : AbstractValidator<UpdateFoodCategoryCommand>
{
    public UpdateFoodCategoryCommandValidator()
    {
        RuleFor(v => v.CategoryName)
            .NotEmpty()
            .WithMessage("CategoryName is required.");
    }
}
