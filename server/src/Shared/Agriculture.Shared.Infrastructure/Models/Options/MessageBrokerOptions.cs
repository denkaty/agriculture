﻿using System.ComponentModel.DataAnnotations;

namespace Agriculture.Shared.Infrastructure.Models.Options
{
    public class MessageBrokerOptions
    {
        [Required]
        public string Host { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
