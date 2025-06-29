using FluentValidation;

namespace Vaultory.Application.Locations;

public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>{
    public UpdateLocationCommandValidator(){
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
    }
}