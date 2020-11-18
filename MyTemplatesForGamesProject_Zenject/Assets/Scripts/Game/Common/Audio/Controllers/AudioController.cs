using System;
using System.Collections.Generic;
using Engine.Mediators;
using Game.Common.Data.GameData;
using UnityEngine;

namespace Game.Common.Audio
{
    public class AudioController : IAudioController, IDisposable, ICommonInitializable
    {
        private readonly AudioSource _sound;
        private readonly IGameSettingsStorage _gameSettings;
        private readonly AudioControllerConfig _config;
        private readonly Dictionary<AudioClip, float> _nextPlayTimeCash;

        public AudioController(IGameSettingsStorage gameSettings, AudioControllerConfig config)
        {
            _gameSettings = gameSettings;
            _config = config;
            _nextPlayTimeCash = new Dictionary<AudioClip, float>();

            _sound = new GameObject("_Sound").AddComponent<AudioSource>();
            _sound.playOnAwake = false;
            _sound.outputAudioMixerGroup = config.Mixer;
            UnityEngine.Object.DontDestroyOnLoad(_sound.gameObject);

            _gameSettings.OnChange += UpdateAudioVolume;
        }

        public void Initialize()
        {
            UpdateAudioVolume();
        }

        public void PlaySound(AudioClip audioClip) => PlaySound(audioClip, _config.DefaultAudioClipConfig);

        public void PlaySound(AudioClip audioClip, AudioClipConfigData clipConfig)
        {
            if (audioClip == null) return; //если нет аудиоклипа - выходим из метода

            //У коллекций есть метод public bool TryGetValue (TKey key, out TValue value) с двумя параметрами:  
            //входной принимает ключ TKey key и выходной параметр TValue value. 
            _nextPlayTimeCash.TryGetValue(audioClip, out var nextPlayTime);
            if (UnityEngine.Time.time < nextPlayTime)
                return;

            _sound.PlayOneShot(audioClip, clipConfig.SoundVolume);
            _nextPlayTimeCash[audioClip] = UnityEngine.Time.time + audioClip.length * (1 - clipConfig.SoundOverlapping);
        }

        private void UpdateAudioVolume()
        {
            _sound.volume = _gameSettings.SoundValue;
        }

        public void Dispose()
        {
            _gameSettings.OnChange -= UpdateAudioVolume;
        }
    }
}