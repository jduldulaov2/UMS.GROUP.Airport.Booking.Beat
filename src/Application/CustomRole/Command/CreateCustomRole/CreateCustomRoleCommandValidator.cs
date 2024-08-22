using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateCustomRoleCommandValidator : AbstractValidator<CreateCustomRoleCommand>
{
    public CreateCustomRoleCommandValidator()
    {
        RuleFor(v => v.RoleName)
            .NotEmpty()
            .WithMessage("RoleName is required.");

    }
}
