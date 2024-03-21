using System;

namespace Infra.Controllers.View
{
    /// <summary>
    /// Defines a basic interface for views in an application, ensuring they can be properly cleaned up by implementing IDisposable.
    /// </summary>
    public interface IView : IDisposable
    {
    }
}