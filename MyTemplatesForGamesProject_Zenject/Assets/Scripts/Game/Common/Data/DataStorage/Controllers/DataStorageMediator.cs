//using Engine.UnityEvent;
using Game.Common.Data.DataStorageBehaviour;
using Game.Common.Data.DefautlValue;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Common.Data.DataStorage
{
    public class DataStorageMediator : IDataStorageMediator 
    {
        private readonly IDataSaveBehaviour _saveBehaviour;
        private readonly IStorageDefautlValueDatabase _storageDefautlValueDatabase;
        private readonly List<IDataStorage> _storages;

        public DataStorageMediator(IDataSaveBehaviour saveBehaviour, IStorageDefautlValueDatabase storageDefautlValueDatabase,
            List<IDataStorage> storages)
        {
            _saveBehaviour = saveBehaviour;
            _storageDefautlValueDatabase = storageDefautlValueDatabase;
            _storages = storages;

            Initialize();
        }

        private void Initialize()
        {
            foreach (var item in _storages)
            {
                Load(item);
                item.OnDataChanged += () => Save(item);
            }
        }

        public void SaveAll()
        {
            foreach (var item in _storages)
            {
                Save(item);
            }
        }

        public object GetStorageDefaultObject(Type type)
        {
            return _storageDefautlValueDatabase.Get(type);
        }

        private void Load(IDataStorage dataStorage)
        {
            var key = dataStorage.Key;
            var obj = _saveBehaviour.GetObject(key, dataStorage.DataType)
                ?? _storageDefautlValueDatabase.Get(dataStorage.DataType);

            if (obj != null) dataStorage.SetData(obj);
        }

        private void Save(IDataStorage dataStorage)
        {
            var obj = dataStorage.GetData();
            var key = dataStorage.Key;
            _saveBehaviour.SetObject(key, obj);
        }
    }
}