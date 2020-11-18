using System.Collections.Generic;
using UnityEngine;

namespace Game.Common.Audio
{
    public class CommonAudioController : ICommonAudioController
    {
        private readonly IAudioController _audio;
        private readonly Dictionary<ECommonAudio, AudioClip> _clips; //словарь объектов Audioclip ключу EСommonAudio
        private readonly Dictionary<ECommonAudio, AudioClipConfigData> _configs;//словарь объектов AudioClipConfigData по ключу EСommonAudio

        public CommonAudioController(IAudioController audio, CommonAudioDatabaseAsset database)
        {
            _audio = audio;
            //Инициализируем словарь с аудиоклипами и добавляем в него конкретные объекты из CommonAudioDatabaseAsset 
            //затем тоже самое делаем для словаря с конфигами/настройками 
            _clips = new Dictionary<ECommonAudio, AudioClip>();
            foreach (var item in database.AudioClips)
                _clips[item.Audio] = item.Clip;

            _configs = new Dictionary<ECommonAudio, AudioClipConfigData>();
            foreach (var item in database.AudioConfigs)
                _configs[item.Audio] = item.Config;
        }

        //главный метод который будет вызываться другими объектами для проигрывания аудио. 
        //Принимает перечисление ECommonAudio с именами аудиоклипов.
        public void PlaySound(ECommonAudio audio)
        {
            //если в словаре с клипами нет аудиоклипа(AudioClip) который соответствует переданному в метод ключу(ECommonAudio) 
            //то выводим сообщение об этом в лог и выходим из метода.
            if (_clips.TryGetValue(audio, out var clip) == false)
            {
                UnityEngine.Debug.LogError($"CommonAudioWrapper: '{audio}' was not found.");
                return;
            }

            //если в словаре с  настройками аудиоклипов есть настройки(AudioClipConfigData) которые соответсвуют ключу(AudioClip) который соответствует переданному в метод ключу(ECommonAudio)
            //вызывает метод PlaySound из AudioController и передаем в него наш аудиоклип и его настройки
            //если настроек нет, то вызываем метод PlaySound из AudioController который принимает только аудиоклип
            //и проигрывает его с дефолтными настройками(это уже в AudioController) 
            if (_configs.TryGetValue(audio, out var config))
            {
                _audio.PlaySound(clip, config);
            }
            else
            {
                _audio.PlaySound(clip);
            }
        }
    }
}
