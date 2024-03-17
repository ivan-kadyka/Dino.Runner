using System.Collections.Generic;
using System.Linq;
using Character.Model;
using Controllers.Spawner.Obstacle.Model;
using Types;
using UniRx;

public class ObstaclesPool : DisposableBase
{
    private readonly Dictionary<int, List<IObstacleView>> _poolDictionary = new Dictionary<int, List<IObstacleView>>();
    private readonly IObstacleFactory _objectFactory;

    private readonly CompositeDisposable _disposable = new CompositeDisposable();

    public ObstaclesPool(IObstacleFactory objectFactory, ICharacterContext characterContext)
    {
        _objectFactory = objectFactory;
        _disposable.Add(characterContext.Speed.Subscribe(OnSpeedUpdate));
    }

    private void OnSpeedUpdate(float speed)
    {
        foreach (var list in _poolDictionary.Values)
        {
            foreach (var item in list.Where(it => it.IsActive))
            {
                item.UpdateSpeed(speed);
            }
        }
    }
    
    public IObstacleView GetObject(int id)
    {
        if (!_poolDictionary.ContainsKey(id))
        {
            _poolDictionary[id] = new List<IObstacleView>();
        }

        var localPool = _poolDictionary[id];
        var availableObject = localPool.FirstOrDefault(it => !it.IsActive);

        if (availableObject == null)
        {
            IObstacleView newObject = _objectFactory.Create(new ObstacleOptions(id));
            localPool.Add(newObject);
            _disposable.Add(newObject);
            availableObject = newObject;
        }

        availableObject.IsActive = true;

        return availableObject;
    }

    public void Reset()
    {
        foreach (var list in _poolDictionary.Values)
        {
            foreach (var item in list)
            {
                item.IsActive = false;
            }
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _disposable.Dispose();
            _poolDictionary.Clear();
        }
    }
}