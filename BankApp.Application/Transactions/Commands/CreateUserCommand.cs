using MediatR;

namespace BankApp.Application.Users.Commands;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email
) : IRequest<int>;