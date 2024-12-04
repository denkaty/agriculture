using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.MediatR;
using Agriculture.Shared.Common.Exceptions.Users;
using Microsoft.AspNetCore.Identity;

namespace Agriculture.Identity.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUserByIdQueryHandler(IAgricultureMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User? existingUser = await _userManager.FindByIdAsync(request.Id);

            if (existingUser == null)
            {
                throw new UserNotFoundException(request.Id);
            }

            var result = _mapper.Map<GetUserByIdQueryResult>(existingUser);

            return result;
        }
    }
}
