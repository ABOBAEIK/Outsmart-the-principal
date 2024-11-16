using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMessaging : MonoBehaviour
{
    public static PlayerMessaging Instance { get; private set; }

    [SerializeField] private Text _message;

    public static void SetText(string message)
        => Instance.SetTextInner(message);

    public static void SetText(string message, float lifeTime) 
        => Instance.SetTextInner(message, lifeTime);

    public static void Clear()
    {
        Instance._message.text = string.Empty;
    }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void SetTextInner(string message)
    {
        _message.text = message;
    }

    public void SetTextInner(string message, float lifeTime)
    {
        StartCoroutine(SetTextCoroutine(message, lifeTime));
    }

    private IEnumerator SetTextCoroutine(string message, float lifetime)
    {
        _message.text = message;
        yield return new WaitForSecondsRealtime(lifetime);
        _message.text = string.Empty;
    }
}
