using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetAllCustomRoleByIDQueryValidator : AbstractValidator<GetAllCustomRoleByIdQuery>
{
    public GetAllCustomRoleByIDQueryValidator()
    {
        RuleFor(x => x.UniqueId)
            .NotEmpty().WithMessage("UniqueId is required.");
    }
}
