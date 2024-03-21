namespace App.Spawner.Coins
{
    internal class CoinView : SpawnView
    {
        protected override void OnColliderHandle()
        {
            gameObject.SetActive(false);
        }
    }
}