﻿using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace VirtualMarket.Common.Authentication
{
    public class JwtAuthAttribute : AuthAttribute
    {
        public JwtAuthAttribute(string policy = "")
            : base(JwtBearerDefaults.AuthenticationScheme, policy)
        {
        }
    }
}
