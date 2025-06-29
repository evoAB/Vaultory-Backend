using FluentValidation;

namespace Vaultory.Application.Locations;

public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>{
    public CreateLocationCommandValidator(){
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
    }
}