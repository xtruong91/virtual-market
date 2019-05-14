using System;

namespace VirtualMarket.Common.Types
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
