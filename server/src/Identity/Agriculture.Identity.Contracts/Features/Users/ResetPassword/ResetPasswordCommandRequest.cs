﻿using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Identity.Contracts.Features.Users.ResetPassword
{
    public class ResetPasswordCommandRequest
    {
        [FromBody]
        public ResetPasswordCommandBindingModel ResetPasswordCommandBindingModel { get; set; } = new(string.Empty, string.Empty, string.Empty, string.Empty);
    }
}
