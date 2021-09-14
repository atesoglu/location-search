using System;
using System.Text.Json;
using Application.Models.Base;

namespace Application.Events.Base
{
    public abstract class Event<T> : EventBase
        where T : ObjectModelBase
    {
        public T Model { get; }

        protected Event(T model, DateTimeOffset requestedAt) : base(requestedAt)
        {
            Model = model;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}