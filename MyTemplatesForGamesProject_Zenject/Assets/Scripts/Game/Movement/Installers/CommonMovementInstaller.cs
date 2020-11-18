using UnityEngine;
using Zenject;

namespace Game.Common.Movement
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Common/CommonMovementInstaller", fileName = "CommonMovementInstaller")]
    public class CommonMovementInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CommonMovementDatabaseAsset _commonMovementDatabase;
        //[SerializeField] private GameObject _moveableGameObject;

        public override void InstallBindings()
        {
            Container.BindInstance(_commonMovementDatabase).AsSingle();

            Container.Bind<IMovementView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<MovementController>().AsSingle().NonLazy();
        }
    }
}
