using System;

namespace Game.Common.Data.DefautlValue
{
    public interface IStorageDefautlValueDatabase
    {
        void Add(object obj);
        object Get(Type type);
        TValue Get<TValue>();
    }
}