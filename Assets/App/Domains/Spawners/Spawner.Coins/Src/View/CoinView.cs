using UnityEngine;

namespace App.Spawner.Coins
{
    public class CoinView : SpawnView
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}