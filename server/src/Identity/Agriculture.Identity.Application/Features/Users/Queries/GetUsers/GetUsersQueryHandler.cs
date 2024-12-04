using Agriculture.Identity.Application.Features.Users.Queries.GetUsers.Dtos;
using Agriculture.Identity.Contracts.Features.Users.GetUsers;
using Agriculture.Identity.Domain.Features.Users.Models.Entities;
using Agriculture.Shared.Application.Abstractions.Mapper;
using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Agriculture.Shared.Domain.Models.Pagination;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;

namespace Agriculture.Identity.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersQueryResult>
    {
        private readonly IAgricultureMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUsersQueryHandler(IAgricultureMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<GetUsersQueryResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _userManager.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(user =>
                user.Email.Contains(request.SearchTerm) ||
                user.PhoneNumber.Contains(request.SearchTerm) ||
                user.FirstName.Contains(request.SearchTerm) ||
                user.LastName.Contains(request.SearchTerm));
            }

            Expression<Func<User, object>> keySelector = request.SortBy.ToLower() switch
            {
                "email" => user => user.Email,
                "firstName" => user => user.FirstName,
                "lastName" => user => user.LastName,
                "phoneNumber" => user => user.PhoneNumber,
                _ => user => user.Email,
            };

            query = request.SortOrder.ToLower() == "desc"
                ? query.OrderByDescending(keySelector)
                : query.OrderBy(keySelector);

            var totalCount = await query.CountAsync(cancellationToken);
            var users = await query.Skip((request.Page - 1) * request.PageSize)
                                   .Take(request.PageSize)
                                   .Select(user =>  new UserDto
                                   {
                                       Id = user.Id,
                                       Email = user.Email,
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       PhoneNumber = user.PhoneNumber,
                                   })
                                   .ToListAsync(cancellationToken);

            var result = _mapper.Map<GetUsersQueryResult>((request, users, totalCount));

            return result;
        }
    }
}
