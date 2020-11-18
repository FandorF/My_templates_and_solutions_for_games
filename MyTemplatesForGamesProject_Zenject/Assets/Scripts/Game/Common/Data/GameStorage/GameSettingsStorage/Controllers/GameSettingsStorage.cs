using System;
using Game.Common.Data.DataStorage;

namespace Game.Common.Data.GameData
{
    public class GameSettingsStorage : IGameSettingsStorage, IDataStorage
    {
        public event Action OnChange;
        public event Action OnDataChanged;

        public string Key => "GameSettingsData";
        public Type DataType => typeof(GameSettingsData);

        public float MusicValue
        {
            get { return _data.MusicValue; }
            set
            {
                _data.MusicValue = value;
                ChangeData();
            }
        }

        public float SoundValue
        {
            get { return _data.SoundValue; }
            set
            {
                _data.SoundValue = value;
                ChangeData();
            }
        }

        public bool NotificationsEnabled
        {
            get { return _data.NotificationsEnabled; }
            set
            {
                _data.NotificationsEnabled = value;
                ChangeData();
            }
        }

        public string Language
        {
            get { return _data.Language; }
            set
            {
                _data.Language = value;
                ChangeData();
            }
        }

        private GameSettingsData _data;

        public GameSettingsStorage()
        {
            _data = new GameSettingsData();
        }

        public void SetData(object input)
        {
            if (input is GameSettingsData data)
            {
                _data = data;
            }
        }

        private void ChangeData()
        {
            OnChange?.Invoke();
            OnDataChanged?.Invoke();
        }

        public object GetData()
        {
            return _data;
        }
    }
}