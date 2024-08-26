using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeleteDraftCartItemsCommandValidator : AbstractValidator<DeleteDraftCartItemsCommand>
{
    public DeleteDraftCartItemsCommandValidator()
    {
        RuleFor(v => v.UniqueId)
            .NotEmpty()
            .WithMessage("UniqueId is required.");

    }
}
