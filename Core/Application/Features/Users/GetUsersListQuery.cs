using Core.Models;
using MediatR;

namespace Core.Application.Features.Users
{
    public class GetUsersListQuery : IRequest<List<User>>
    {
    }
}