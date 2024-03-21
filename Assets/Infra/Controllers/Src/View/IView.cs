using System;

namespace Infra.Controllers.View
{
    /// <summary>
    /// Defines a basic interface for views in an application, ensuring they can be properly cleaned up by implementing IDisposable.
    /// </summary>
    public interface IView : IDisposable
    {
        // This interface can be expanded with methods and properties that are common to all views
    }
}