using FluentValidation;

namespace BankApp.Application.Transactions.Commands
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(x => x.AccountId).GreaterThan(0).WithMessage("AccountId must be greater than 0");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0");
            RuleFor(x => x.Amount).NotEqual(0).WithMessage("Amount cannot be zero");
            RuleFor(x => x.Type)
                .NotEmpty()
                .Must(type => type.Equals("credit", StringComparison.OrdinalIgnoreCase) || 
                             type.Equals("debit", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Type must be either 'credit' or 'debit'");
            RuleFor(x => x.Description)
                .MaximumLength(255)
                .WithMessage("Description cannot exceed 255 characters");
        }
    }
}
