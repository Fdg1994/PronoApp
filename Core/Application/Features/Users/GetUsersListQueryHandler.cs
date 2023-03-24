using AutoMapper;
using Core.Application.Contracts.Persistence;
using Core.Domain.Entities;
using Core.Models;
using MediatR;

namespace Core.Application.Features.Users
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<User>>
    {
        private readonly IAsyncRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IAsyncRepository<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _userRepository.ListAllAsync()).OrderBy(u => u.UserName);
            return _mapper.Map<List<User>>(allUsers);
        }
    }
}