using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdateCustomRoleCommandValidator : AbstractValidator<UpdateCustomRoleCommand>
{
    public UpdateCustomRoleCommandValidator()
    {
        RuleFor(v => v.RoleName)
            .NotEmpty()
            .WithMessage("PromoCode is required.");
    }
}
