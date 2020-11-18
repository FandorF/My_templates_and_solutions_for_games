using System;
using System.Collections.Generic;
using Zenject;
using System.Linq;
using UnityEngine;

namespace Engine.Mediators
{
    public class InitializeMediator : Zenject.IInitializable, IInitializeMediator, IDisposable
    {
        public event Action OnDone;

        private readonly List<ICommonInitializable> _commonInitializables;
        private readonly List<IDataInitializable> _dataInitializables;
        private readonly List<IOrderedInitializable> _orderedInitializables;

        public InitializeMediator(
           [Inject(Optional = true, Source = InjectSources.Local)] List<ICommonInitializable> commonInitializables,
           [Inject(Optional = true, Source = InjectSources.Local)] List<IDataInitializable> dataInitializables,
           [Inject(Optional = true, Source = InjectSources.Local)] List<IOrderedInitializable> orderedInitializables)
        {
            _commonInitializables = commonInitializables;
            _orderedInitializables = orderedInitializables;
            _dataInitializables = dataInitializables;
        }

        public void Initialize()
        {
            foreach(var item in _commonInitializables)
            {
                item.Initialize();
                Debug.LogError("Initialize");
            }

            var ordered = _orderedInitializables.OrderBy(x => x.InitializationOrder);
            foreach (var item in ordered)
            {
                item.Initialize();
            }

            foreach (var item in _dataInitializables)
            {
                item.Initialize();
            }
            OnDone?.Invoke();
        }

        public void Dispose()
        {
            OnDone = null;
        }
    }
}
