using Observables;

namespace App.Models
{
    public interface IGameContext
    {
        IObservableValue<float> Speed { get; }
    }
}