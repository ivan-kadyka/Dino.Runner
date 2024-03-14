namespace Types
{
    using System;
    using System.Threading;
    
        public abstract class DisposableBase : IDisposable
        {
#if UNITY_EDITOR || PROFILING_ENABLED
            public static event Action<IDisposable> RegisterDisposable;
            public static event Action<IDisposable> UnRegisterDisposable;
            public static event Action<IDisposable> FinalizerCall;
            public static event Action<IDisposable> DoubleDispose;
#endif
            private int _disposed;

            protected bool IsDisposed => _disposed == 1;
            protected DisposableBase()
            {
#if UNITY_EDITOR || PROFILING_ENABLED
                RegisterDisposable?.Invoke(this);
#endif
            }

#if UNITY_EDITOR || PROFILING_ENABLED
            ~DisposableBase()
            {
                FinalizerCall?.Invoke(this);
                Dispose(false);
            }
#endif

            #region IDisposable implementation

            public void Dispose()
            {
                var disposed = Interlocked.CompareExchange(ref _disposed, 1, 0);

                if (disposed == 0)
                {
                    GC.SuppressFinalize(this);
#if UNITY_EDITOR || PROFILING_ENABLED
                    UnRegisterDisposable?.Invoke(this);
#endif

                    Dispose(true);

                    _disposed |= 2;
                }
                else
                {
#if UNITY_EDITOR || PROFILING_ENABLED
                    DoubleDispose?.Invoke(this);
#endif
                }
            }

            #endregion

            protected abstract void Dispose(bool disposing);
        }
}