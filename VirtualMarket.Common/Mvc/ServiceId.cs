﻿using System;

namespace VirtualMarket.Common.Mvc
{
    public class ServiceId : IServiceId
    {
        private static readonly string UniqueId = $"{Guid.NewGuid():N}";
        public string Id => UniqueId;
       
    }
}
