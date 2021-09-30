using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using Maway.BusinessLogic.QueryData;
using MediatR;

namespace Maway.BusinessLogic.Queries
{
    public class GetAvailableItemsQuery : IRequest<IEnumerable<ItemQueryData>>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class GetAvailableItemsQueryValidator : AbstractValidator<GetAvailableItemsQuery>
    {
        public GetAvailableItemsQueryValidator()
        {
            RuleFor(x => x.From)
                .NotEmpty()
                .WithMessage("Podaj początek zakresu dat dla rezerwacji");

            RuleFor(x => x.From.Date)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Początek zakresu dat musi być datą z przyszłości");

            RuleFor(x => x.To)
                .NotEmpty()
                .WithMessage("Podaj koniec zakresu dat dla rezerwacji");

            RuleFor(x => x)
                .Custom((x, ctx) =>
                {
                   if(x.From.Date > x.To.Date)
                        ctx.AddFailure(new ValidationFailure(
                $"From", 
                $"Początek zakresu musi być mniejszy od końca"));
                });
                
        }
    }
}
