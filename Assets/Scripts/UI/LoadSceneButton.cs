using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Game.LoadScene(sceneName, "Test loading " + sceneName, "There will be tip");
    }
}