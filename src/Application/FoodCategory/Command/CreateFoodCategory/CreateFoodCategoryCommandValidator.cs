using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateFoodCategoryCommandValidator : AbstractValidator<CreateFoodCategoryCommand>
{
    public CreateFoodCategoryCommandValidator()
    {
        RuleFor(v => v.CategoryName)
            .NotEmpty()
            .WithMessage("CategoryName is required.");
    }
}
