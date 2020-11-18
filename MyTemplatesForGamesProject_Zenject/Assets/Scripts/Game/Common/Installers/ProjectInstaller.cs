using Engine.Mediators;
using Engine.UnityEvent;
using Game.Engine;
using Zenject;

namespace Game.Common.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnityEventProjectMediator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<CoroutineManager>().AsSingle();
            Container.BindInterfacesTo<InitializeMediator>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DisposableMediator>().AsSingle().NonLazy();

            Container.Bind<ICoroutineProjectManager>().To<CoroutineProjectManager>().AsSingle();
        }
    }
}
