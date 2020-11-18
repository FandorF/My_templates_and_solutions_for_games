using System;
using UnityEngine;

namespace Game.Common.Audio
{
    [Serializable]
    public class AudioClipConfigData  //данные настроек звука
    {
        public float SoundOverlapping => _soundOverlapping;
        public float SoundVolume => _soundVolume;

        [SerializeField] [Range(0, 1)] private float _soundOverlapping = 0.5f;
        [SerializeField] [Range(0, 1)] private float _soundVolume = 1;
    }
}
