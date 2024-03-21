namespace App.GameCore
{
    public class CoinObject : IObject
    {
        public ObjectType ObjectType { get; }
        
        public CoinType CoinType { get; }
        

        public CoinObject(CoinType coinType)
        {
            CoinType = coinType;
            ObjectType = ObjectType.Coin;
        }
    }
}