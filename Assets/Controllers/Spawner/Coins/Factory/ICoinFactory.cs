using Controllers.Spawner.Coins.View;
using Zenject;

namespace Controllers.Spawner.Coins.Factory
{
    public interface ICoinFactory : IFactory<CoinOptions, ICoinView>
    {
    }

    public class CoinOptions
    {
        
    }
}