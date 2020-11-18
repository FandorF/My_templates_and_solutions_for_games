using System;

namespace Game.Common.Data.DataStorage
{
    public interface IDataStorageMediator
    {
        void SaveAll();

        object GetStorageDefaultObject(Type type);
    }
}