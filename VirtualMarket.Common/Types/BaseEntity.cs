using System;

namespace VirtualMarket.Common.Types
{
    public abstract class BaseEntity : IIdentifiable
    {
        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime UpdateDate { get; protected set; }
        public BaseEntity(Guid id)
        {
            Id = id;
            CreateDate = DateTime.UtcNow;
            SetUpdateDate();
        }

        protected virtual void SetUpdateDate()
            => UpdateDate = DateTime.UtcNow;
    }
}
