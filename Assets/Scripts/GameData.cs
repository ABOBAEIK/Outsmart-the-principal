using System;

namespace GameDatas
{
    [Serializable]
    public class GameData
    {
        public MenuData Menu;
        public MainGameData MainGame;
    }

    [Serializable]
    public struct MenuData
    {
        public string PlayText;
        public string SettingsText;
    }

    [Serializable]
    public struct MainGameData
    {
        public ItemData[] Items;
    }

    [Serializable]
    public struct ItemData
    {
        public string Name;
        public string Icon;
    }
}