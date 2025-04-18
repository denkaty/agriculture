﻿namespace Agriculture.Identity.Application.Features.Users.Models
{
    public record CreateAccessTokenModel(
        string UserId,
        string Email,
        string FirstName,
        string LastName,
        string[] Roles);
}
