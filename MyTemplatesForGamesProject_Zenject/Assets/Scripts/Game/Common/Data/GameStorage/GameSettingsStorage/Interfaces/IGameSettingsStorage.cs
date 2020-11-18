using System;

namespace Game.Common.Data.GameData
{
    public interface IGameSettingsStorage
    {
        event Action OnChange;

        float MusicValue { get; set; }
        float SoundValue { get; set; }
        bool NotificationsEnabled { get; set; }
        string Language { get; set; }
    }
}