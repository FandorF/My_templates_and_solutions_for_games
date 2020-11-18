using System;
using Zenject;
using UnityEngine;
using Game.Common.Data;
using Game.Common.Data.GameData;
using Game.Common.Data.DataStorage;
using Game.Common.Data.DataStorageBehaviour;
using Game.Common.Data.Serializer;
using Game.Common.Data.DefautlValue;

namespace Game.Common.Installers
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Common/GameSettingsInstaller", fileName = "GameSettingsInstaller")]

    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        //[SerializeField] private GameDataShowerAsset _gameDataSaver;

        [SerializeField] private StorageDefautlValueAssets _storageDefautlValueAssets;

        public override void InstallBindings()
        {
            Container.BindInstance(_storageDefautlValueAssets);

            //Container.BindInstance(_gameDataSaver);

            BindDataServices();
        }

        private void BindDataServices()
        {
            Container.BindInterfacesTo<JsonUtilitySerializer>().AsSingle();
            Container.BindInterfacesTo<PrefsStorageBehaviour>().AsSingle();
            Container.BindInterfacesTo<GameSettingsStorage>().AsSingle();
            Container.BindInterfacesTo<DataStorageMediator>().AsSingle().NonLazy();

            Container.BindInterfacesTo<StorageDefautlValueDatabase>().AsSingle();
        }
    }
}
