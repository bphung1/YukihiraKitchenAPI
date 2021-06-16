using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukihiraKitchen.Application.Directions
{
    public class DirectionValidator : AbstractValidator<DirectionParam>
    {
        public DirectionValidator()
        {
            RuleFor(x => x.StepNumber).NotEmpty();
            RuleFor(x => x.CookingDirection).NotEmpty();
        }
    }
}
