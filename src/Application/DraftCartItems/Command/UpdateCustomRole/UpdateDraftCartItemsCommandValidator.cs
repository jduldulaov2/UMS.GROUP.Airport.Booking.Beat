using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdateDraftCartItemsCommandValidator : AbstractValidator<UpdateDraftCartItemsCommand>
{
    public UpdateDraftCartItemsCommandValidator()
    {
        RuleFor(v => v.BookingReservationId)
            .NotEmpty()
            .WithMessage("BookingReservationId is required.");
    }
}
