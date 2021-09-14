using System;

namespace Application.Events.Base
{
    public abstract class EventBase
    {
        public bool IsPublished { get; set; }
        public DateTimeOffset RequestedAt { get; }

        protected EventBase()
        {
            RequestedAt = DateTimeOffset.Now;
        }

        protected EventBase(DateTimeOffset requestedAt)
        {
            RequestedAt = requestedAt;
        }
    }
}