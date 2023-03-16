﻿using API.Application.Commands;
using FluentValidation;

namespace API.Application.Validators
{
    public class OrderPlacedCommandValidator : AbstractValidator<OrderPlacedCommand>
    {
        public OrderPlacedCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Quantity).NotEmpty();
        }
    }
}