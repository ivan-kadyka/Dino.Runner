using System;

namespace Infra.Components.Tickable
{
    /// <summary>
    /// Provides a context for managing and observing frame updates.
    /// </summary>
    public interface ITickableContext
    {
        /// <summary>
        /// An observable sequence of updates, emitting the elapsed
        /// time in milliseconds since the last update.
        /// </summary>
        IObservable<float> Updated { get; }
    }
}