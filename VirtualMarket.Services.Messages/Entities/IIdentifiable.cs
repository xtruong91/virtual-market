using System;

namespace VirtualMarket.Services.Messages.Entities
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
