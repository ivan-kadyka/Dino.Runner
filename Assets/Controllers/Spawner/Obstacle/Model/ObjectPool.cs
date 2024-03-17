using System.Collections.Generic;
using System.Linq;
using Controllers.Spawner.Obstacle.Model;
using Types;

public class ObstaclesPool : DisposableBase
{
    private readonly Dictionary<int, List<IObstacleView>> _poolDictionary = new Dictionary<int, List<IObstacleView>>();
    private readonly IObstacleFactory _objectFactory;

    public ObstaclesPool(IObstacleFactory objectFactory)
    {
        _objectFactory = objectFactory;
    }
    
    public IObstacleView GetObject(int id)
    {
        if (!_poolDictionary.ContainsKey(id))
        {
            _poolDictionary[id] = new List<IObstacleView>();
        }

        var localPool = _poolDictionary[id];
        var availableObject = localPool.FirstOrDefault(it => it.IsActive);

        if (availableObject == null)
        {
            IObstacleView newObject = _objectFactory.Create(new ObstacleOptions(id));
            localPool.Add(newObject);
            availableObject = newObject;
        }

        availableObject.IsActive = true;

        return availableObject;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            foreach (var pool in _poolDictionary.Values)
            {
                foreach (var item in pool)
                {
                    item.Dispose();
                }
                
                pool.Clear();
            }
        }
    }
}