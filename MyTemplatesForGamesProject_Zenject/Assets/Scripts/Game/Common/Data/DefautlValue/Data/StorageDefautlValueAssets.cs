using Game.Common.Data.GameData;
using System.Linq;
using UnityEngine;

namespace Game.Common.Data.DefautlValue
{
    //хранилище значений по умолчанию
    //метод GetObjects возвращает объекты с данными по умолчанию.
    [CreateAssetMenu(menuName = "ScriptableObject/Database/StorageDefautlValueAssets", fileName = "StorageDefautlValueAssets")]
    public class StorageDefautlValueAssets : ScriptableObject 
    {
        [SerializeField] private GameSettingsData _gameSettingsData;

        public object[] GetObjects() //метод возвращает массив объектов
        {
            return new object[]
            {
                _gameSettingsData,
            };
        }
    }
}