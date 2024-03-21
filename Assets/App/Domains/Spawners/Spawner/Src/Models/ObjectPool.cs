using System.Collections.Generic;
using System.Linq;
using Types;
using UniRx;

namespace App.Spawner
{
    public class SpawnPool<TOptions, TView>  : DisposableBase
        where TView : class, ISpawnView
        where TOptions: SpawnOptions
    {
        private readonly Dictionary<int, List<TView>> _poolDictionary = new Dictionary<int, List<TView>>();
        private readonly ISpawnFactory<TOptions, TView> _objectFactory;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SpawnPool(ISpawnFactory<TOptions, TView> objectFactory)
        {
            _objectFactory = objectFactory;
        }
    
        public TView GetObject(TOptions options)
        {
            var id = options.Id;
        
            if (!_poolDictionary.ContainsKey(id))
            {
                _poolDictionary[id] = new List<TView>();
            }

            var localPool = _poolDictionary[id];
            var availableObject = localPool.FirstOrDefault(it => !it.IsActive);

            if (availableObject == null)
            {
                var newObject = _objectFactory.Create(options);
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
}