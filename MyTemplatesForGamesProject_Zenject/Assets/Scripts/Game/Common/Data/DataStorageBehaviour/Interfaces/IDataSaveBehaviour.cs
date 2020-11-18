using System;

namespace Game.Common.Data.DataStorageBehaviour
{
    public interface IDataSaveBehaviour
    {
        void SetObject(string key, object obj);
        object GetObject(string key, Type type);
    }
}