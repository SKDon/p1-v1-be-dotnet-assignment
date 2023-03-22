using API.Application.Queries.GetFlightById;
using FluentValidation;

namespace API.Application.Validators
{
    public class GetFlightByIdValidator : AbstractValidator<GetFlightByIdQuery>
    {
        public GetFlightByIdValidator()
        {
            RuleFor(c => c.Code).NotEmpty();
        }
    }
}
