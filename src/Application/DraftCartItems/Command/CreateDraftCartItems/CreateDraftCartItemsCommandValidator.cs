using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateDraftCartItemsCommandValidator : AbstractValidator<CreateDraftCartItemsCommand>
{
    public CreateDraftCartItemsCommandValidator()
    {
        RuleFor(v => v.BookingReservationId)
            .NotEmpty()
            .WithMessage("RoleName is required.");

    }
}
