using App.Domains.Spawner.View;
using UnityEngine;

namespace App.Domains.Spawner.Coins.View
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