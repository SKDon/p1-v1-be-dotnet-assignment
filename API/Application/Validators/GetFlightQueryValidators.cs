using API.Application.Commands;
using API.Application.Queries.GetFlight;
using FluentValidation;

namespace API.Application.Validators
{
    public class GetFlightQueryValidators : AbstractValidator<GetFlightQuery>
    {
        public GetFlightQueryValidators()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
