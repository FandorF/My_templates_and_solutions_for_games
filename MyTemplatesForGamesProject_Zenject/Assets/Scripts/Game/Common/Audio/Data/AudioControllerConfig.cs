using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Common.Audio
{
    [Serializable]
    public class AudioControllerConfig  //настройки звука, микшера и перекрытия для аудиоконтроллера
    {
        public AudioMixerGroup Mixer => _mixer;
        public AudioClipConfigData DefaultAudioClipConfig => _defaultAudioClipConfig;   //данные настроек звука

        [SerializeField] private AudioMixerGroup _mixer;  //микшер 
        [SerializeField] AudioClipConfigData _defaultAudioClipConfig; //дефолтные настройки громкости и перекрытия
    }
}
