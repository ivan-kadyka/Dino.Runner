using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Types
{
    using System;
    using System.Threading;
    
        public abstract class DisposableBase : IDisposable
        {
            private int _disposed;

            protected bool IsDisposed => _disposed == 1;
            
            ~DisposableBase()
            {
#if UNITY_EDITOR || PROFILING_ENABLED
                if (Debugger.IsAttached)
                {
                    Debug.LogWarning($"Executing Dispose from finalizer call for object '{GetType().FullName}'");
                    Debugger.Break();
                }
#endif
                Dispose(false);
            }


            #region IDisposable implementation

            public void Dispose()
            {
                var disposed = Interlocked.CompareExchange(ref _disposed, 1, 0);

                if (disposed == 0)
                {
                    GC.SuppressFinalize(this);
                    Dispose(true);

                    _disposed |= 2;
                }
                else
                {
#if UNITY_EDITOR || PROFILING_ENABLED
                    if (Debugger.IsAttached)
                    {
                        Debug.LogWarning($"Double disposed object '{GetType().FullName}'");
                        Debugger.Break();
                    }
#endif
                }
            }

            #endregion

            protected abstract void Dispose(bool disposing);
        }
}