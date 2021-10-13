using System.Threading;
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
            if (validator != null)
            {
                var result = await validator.ValidateAsync(new ValidationContext<TRequest>(request), cancellationToken);

                if (result is { IsValid: false })
                {
                    throw new ValidationException(result.Errors);
                }
            }
            return await next();
        }
    }
}