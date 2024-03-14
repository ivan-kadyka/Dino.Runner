using UnityEngine;

namespace Character.View
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        public void Move()
        {
            Debug.Log("Character move");
        }
    }
}