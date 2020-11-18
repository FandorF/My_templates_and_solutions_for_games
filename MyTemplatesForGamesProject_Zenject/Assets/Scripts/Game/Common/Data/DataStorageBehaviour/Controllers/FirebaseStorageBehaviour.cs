using System;

namespace Game.Common.Data.DataStorageBehaviour
{
    public class FirebaseStorageBehaviour : IDataSaveBehaviour
    {
        public object GetObject(string key, Type type)
        {
            throw new NotImplementedException();
        }

        public void SetObject(string key, object obj)
        {
            throw new NotImplementedException();
        }
    }
}