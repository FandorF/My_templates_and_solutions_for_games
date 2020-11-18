using System.Collections.Generic;
using UnityEngine;

namespace Game.Common.Audio
{
    [CreateAssetMenu(menuName = "ScriptableObject/Database/CommonAudioDatabase", fileName = "CommonAudioDatabase")]
    public class CommonAudioDatabaseAsset : ScriptableObject
    {
        public IReadOnlyList<CommonAudioClipData> AudioClips => _audioClips;
        public IReadOnlyList<CommonAudioConfigData> AudioConfigs => _audioConfigs;

        [SerializeField] private List<CommonAudioClipData> _audioClips;
        [SerializeField] private List<CommonAudioConfigData> _audioConfigs;
    }
}