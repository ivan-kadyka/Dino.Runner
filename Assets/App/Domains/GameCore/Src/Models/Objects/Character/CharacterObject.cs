namespace App.GameCore.Character
{
    public class CharacterObject : IObject
    {
        public ObjectType ObjectType { get; }

        public CharacterObject()
        {
            ObjectType = ObjectType.Character;
        }
    }
}