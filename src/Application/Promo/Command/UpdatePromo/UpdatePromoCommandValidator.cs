using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdatePromoCommandValidator : AbstractValidator<UpdatePromoCommand>
{
    public UpdatePromoCommandValidator()
    {
        RuleFor(v => v.PromoCode)
            .NotEmpty()
            .WithMessage("PromoCode is required.");

        RuleFor(v => v.PromoName)
            .NotEmpty()
            .WithMessage("PromoName is required.");
    }
}
