﻿namespace Agriculture.Identity.Contracts.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
