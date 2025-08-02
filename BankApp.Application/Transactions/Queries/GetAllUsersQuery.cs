using MediatR;
using System.Collections.Generic;

namespace BankApp.Application.Users.Queries
{
    public record GetAllUsersQuery() : IRequest<List<UserDto>>;
}