using System;

namespace Game.Common.Data.DataStorage
{
    public interface IDataStorage
    {
        event Action OnDataChanged;

        string Key { get; }
        Type DataType { get; }

        void SetData(object input);
        object GetData();
    }
}