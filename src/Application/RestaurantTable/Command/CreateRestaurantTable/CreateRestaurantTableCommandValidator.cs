using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateRestaurantTableCommandValidator : AbstractValidator<CreateRestaurantTableCommand>
{
    public CreateRestaurantTableCommandValidator()
    {
        RuleFor(v => v.TableName)
            .NotEmpty()
            .WithMessage("TableName is required.");
    }
}
