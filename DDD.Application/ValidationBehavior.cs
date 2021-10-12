﻿using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace DDD.Application
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidatorFactory _validationFactory;

        public ValidationBehavior(IValidatorFactory validationFactory)
        {
            _validationFactory = validationFactory;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var validator = _validationFactory.GetValidator(request.GetType());
            var result = validator?.Validate(new ValidationContext<TRequest>(request));

            if (result is { IsValid: false })
            {
                throw new ValidationException(result.Errors);
            }

            var response = await next();

            return response;
        }
    }
}