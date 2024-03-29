﻿using System;

namespace VirtualMarket.Services.Storage.Models.Identity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
