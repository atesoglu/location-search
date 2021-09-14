using System;

namespace Application.Request
{
    /// <summary>
    /// Generic request base
    /// </summary>
    public interface IRequestBase
    {
        DateTimeOffset RequestedAt { get; set; }
    }
}