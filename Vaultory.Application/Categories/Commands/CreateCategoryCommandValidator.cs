using FluentValidation;

namespace Vaultory.Application.Categories;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>{
    public CreateCategoryCommandValidator(){
        RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
    }
}