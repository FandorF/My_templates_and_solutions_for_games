using UnityEngine;
using Zenject;

namespace Game.Common.Audio
{
    [CreateAssetMenu(menuName = "ScriptableObject/Installers/Common/CommonAudioInstaller", fileName = "CommonAudioInstaller")]
    public class CommonAudioInstaller : ScriptableObjectInstaller<CommonAudioInstaller>
    {
        [SerializeField] private CommonAudioDatabaseAsset _commonAudioDatabase;
        [SerializeField] private AudioControllerConfig _audioControllerConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_commonAudioDatabase).AsSingle();

            Container.BindInterfacesTo<AudioController>().AsSingle().WithArguments(_audioControllerConfig);
            Container.BindInterfacesTo<CommonAudioController>().AsSingle();
        }
    }
}
