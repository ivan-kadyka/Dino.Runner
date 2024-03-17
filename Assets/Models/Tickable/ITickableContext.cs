using System;

namespace Models.Tickable
{
    public interface ITickableContext
    {
        
        /// <summary>
        /// 
        /// </summary>
        IObservable<float> Updated { get; }
    }
}