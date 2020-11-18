using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Common.Data.DefautlValue
{
    //Хранилище значений по умолчанию. Контроллер.
    public class StorageDefautlValueDatabase : IStorageDefautlValueDatabase
    {
        private readonly StorageDefautlValueAssets _storageDefautlValueAssets;
        private readonly Dictionary<Type, object> _dictionary;//словарь объектов по ключу-Type. хранит объекты по умолчанию. 

        public StorageDefautlValueDatabase(StorageDefautlValueAssets storageDefautlValueAssets)
        {
            _storageDefautlValueAssets = storageDefautlValueAssets;
            _dictionary = new Dictionary<Type, object>();

            foreach (var item in _storageDefautlValueAssets.GetObjects())
                Add(item);
        }

        public void Add(object obj)
        {
            _dictionary.Add(obj.GetType(), obj);
        }

        public object Get(Type type)
        {
            if (_dictionary.ContainsKey(type))
                return Clone(_dictionary[type]);

            return null;
        }

        public TValue Get<TValue>()
        {
            if (_dictionary.ContainsKey(typeof(TValue)))
                return (TValue) Clone(_dictionary[typeof(TValue)]);

            UnityEngine.Debug.LogError($"StorageDefautlValueDatabase: '{typeof(TValue)}' was not found.");

            return default;
        }

        private object Clone(object obj)
        {
            if (obj is ICloneable cloneable)
                return cloneable.Clone();

            UnityEngine.Debug.LogError($"StorageDefautlValueDatabase: '{obj.GetType()}' does not implement ICloneable.");

            return obj;
        }
    }
}