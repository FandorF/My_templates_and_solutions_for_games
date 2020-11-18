using UnityEngine;

namespace Game.Common.Audio
{
    public interface IAudioController
    {
        void PlaySound(AudioClip audioClip, AudioClipConfigData configData);
        void PlaySound(AudioClip audioClip);
    }
}
