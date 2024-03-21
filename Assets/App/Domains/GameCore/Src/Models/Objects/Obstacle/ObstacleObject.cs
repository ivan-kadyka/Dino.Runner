namespace App.GameCore.Obstacle
{
    public class ObstacleObject : IObject
    {
        public ObjectType ObjectType { get; }

        public ObstacleObject()
        {
            ObjectType = ObjectType.Obstacle;
        }
    }
}