using System;

namespace VirtualMarket.Services.Messages.Entities
{
    public class BaseEntity : IIdentifiable
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime UpdateDate { get; protected set; }

        public BaseEntity(Guid id)
        {
            Id = id;
            CreatedDate = DateTime.UtcNow;
            SetUpdatedDate();
        }
        protected virtual void SetUpdatedDate()
        => UpdateDate = DateTime.UtcNow;
    }
}
