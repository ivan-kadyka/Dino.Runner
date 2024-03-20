using System;

namespace Infra.Components.Tickable
{
    public interface ITickableContext
    {
        
        /// <summary>
        /// 
        /// </summary>
        IObservable<float> Updated { get; }
    }
}