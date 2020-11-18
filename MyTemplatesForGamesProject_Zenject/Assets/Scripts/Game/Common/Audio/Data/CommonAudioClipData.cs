using System;
using UnityEngine;

namespace Game.Common.Audio
{
    //в класс будут добавлены аудиоклипы 
    [Serializable]
    public class CommonAudioClipData // общие аудиоклипданные 
    {
        public ECommonAudio Audio => _audio;  //имена
        public AudioClip Clip => _clip;     //сами клипы

        [SerializeField] private ECommonAudio _audio;
        [SerializeField] private AudioClip _clip;
    }
}
