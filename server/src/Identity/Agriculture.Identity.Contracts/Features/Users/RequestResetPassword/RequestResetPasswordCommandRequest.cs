﻿using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Contracts.Features.Users.RequestResetPassword
{
    public class RequestResetPasswordCommandRequest
    {
        [FromBody]
        public RequestResetPasswordCommandBindingModel RequestResetPasswordCommandBindingModel { get; set; } = new(string.Empty);
    }
}
