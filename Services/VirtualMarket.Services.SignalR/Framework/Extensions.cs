using System;

namespace VirtualMarket.Services.SignalR.Framework
{
    public static class Extensions
    {
        public static string ToUserGroup(this Guid userId)
            => $"users:{userId}";
    }
}
