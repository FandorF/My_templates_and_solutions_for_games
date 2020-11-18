using System;

namespace Game.Common.Data.Serializer
{
    public interface IObjectStringSerializer
    {
        object ToObject(string input, Type type);
        string ToString(object input); 
    }
}