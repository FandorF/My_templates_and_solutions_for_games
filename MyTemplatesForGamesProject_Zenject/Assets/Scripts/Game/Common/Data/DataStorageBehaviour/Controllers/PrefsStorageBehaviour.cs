using Game.Common.Data.Serializer;
using System;
using UnityEngine;

namespace Game.Common.Data.DataStorageBehaviour
{
    //класс сохраняет данные в плеерпрефс и предоставляет сохраненные.
    public class PrefsStorageBehaviour : IDataSaveBehaviour
    {
        private readonly IObjectStringSerializer _serializer;   //сериалайзер сериализует данные 

        public PrefsStorageBehaviour(IObjectStringSerializer serializer)
        {
            _serializer = serializer;
        }

        //метод "ВзятьОбъект". Принимает ключь-строку, тип объекта 
        //и в сериалайзере десериализует ключь в объект и возвращает object
        public object GetObject(string key, Type type)
        {
            var serializeObject = PlayerPrefs.GetString(key);
            return string.IsNullOrEmpty(serializeObject) ? null : _serializer.ToObject(serializeObject, type);
        }

        //Метод сохраняет данные в PlyerPrefs
        //берет объект и сериализует его в строку, затем записывает в PlayerPrefs
        public void SetObject(string key, object obj)
        {
            var serializeObject = _serializer.ToString(obj);
            PlayerPrefs.SetString(key, serializeObject);
            PlayerPrefs.Save();
        }
    }
}