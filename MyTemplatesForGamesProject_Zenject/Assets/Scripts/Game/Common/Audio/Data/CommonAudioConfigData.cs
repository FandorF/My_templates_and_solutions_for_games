using UnityEngine;

namespace Game.Common.Audio
{
    [System.Serializable]
    public class CommonAudioConfigData
    {
        public ECommonAudio Audio => _audio;
        public AudioClipConfigData Config => _config;

        [SerializeField] ECommonAudio _audio;
        [SerializeField] AudioClipConfigData _config;  //настройки
    }
}
