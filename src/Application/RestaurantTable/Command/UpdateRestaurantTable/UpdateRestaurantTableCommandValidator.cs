using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdateRestaurantTableCommandValidator : AbstractValidator<UpdateRestaurantTableCommand>
{
    public UpdateRestaurantTableCommandValidator()
    {
        RuleFor(v => v.TableName)
            .NotEmpty()
            .WithMessage("TableName is required.");
    }
}
