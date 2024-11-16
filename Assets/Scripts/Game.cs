using UnityEngine;
using UnityEngine.SceneManagement;

using GameDatas;

public static class Game
{
    public static GameData AllGameData;

    private static Language _currentLanguage;

    static Game()
    {
        AllGameData = new GameData();

        ChangeLanguage(Language.Rus);
    }

    public static void LoadScene(string name, string title, string tip)
    {
        LoadSceneDisplay.MonitorLoading(SceneManager.LoadSceneAsync(name, LoadSceneMode.Single), title, tip);
    }

    public static void ChangeLanguage(Language newLang)
    {
        _currentLanguage = newLang;

        TextAsset jsonAsset = Resources.Load<TextAsset>("gameDataReferences_" + newLang);

        AllGameData = JsonUtility.FromJson<GameData>(jsonAsset.text);
    }

    public static Language GetLanguage()
        => _currentLanguage;

    public enum Language
    {
        Eng,
        Rus
    }
}