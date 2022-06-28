using System.Data;
using FluentValidation;
using warehouse.Create;
using warehouse.Database;

namespace warehouse.Validators;

public class CreateUserValidator:AbstractValidator<CreateUser>
{
    public CreateUserValidator(AppDbContext dbContext)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Password).MinimumLength(6);
        RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
        RuleFor(x => x.Email)
            .Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(x => x.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "Email is taken");
                }
            });
    }
}