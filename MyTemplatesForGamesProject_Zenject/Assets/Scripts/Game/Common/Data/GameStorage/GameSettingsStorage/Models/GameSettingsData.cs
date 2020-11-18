using System;

namespace Game.Common.Data.GameData
{
    [Serializable]
    public class GameSettingsData : ICloneable
    {
        public float MusicValue;
        public float SoundValue;
        public bool NotificationsEnabled;
        public string Language;

        public object Clone()
        {
            return new GameSettingsData()
            {
                MusicValue = MusicValue,
                SoundValue = SoundValue,
                NotificationsEnabled = NotificationsEnabled,
                Language = Language,
            };
        }
    }
}