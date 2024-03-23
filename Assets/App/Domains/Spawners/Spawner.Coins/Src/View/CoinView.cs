using App.GameCore;
using App.GameCore.Character;
using UnityEngine;

namespace App.Spawner.Coins
{
    internal class CoinView : SpawnView
    {
        void OnTriggerEnter(Collider other)
        {
            var objectView = other.GetComponent<IObjectView>();
            
            if (objectView != null && objectView.Object is CharacterObject)
            {
                gameObject.SetActive(false);
            }
        }
    }
}