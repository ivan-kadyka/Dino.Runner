namespace App.GameCore.Sender
{
    public class ColliderSender
    {
        private readonly IObject _currentObject;

        public ColliderSender(IObject currentObject)
        {
            _currentObject = currentObject;
        }

        public void Send()
        {
            
        }
    }
}