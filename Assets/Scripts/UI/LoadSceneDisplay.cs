using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneDisplay : MonoBehaviour
{
    public static LoadSceneDisplay Instance { get; private set; }

    [SerializeField] private Transform _mainParent;

    [SerializeField] private Text _title;
    [SerializeField] private Transform _background;
    [SerializeField] private Image _progressBar;
    [SerializeField] private Text _tip;

    private AsyncOperation _monitoringOperation;

    public static void MonitorLoading(AsyncOperation loading, string title, string tip)
    {
        CheckInstance();

        Instance._mainParent.gameObject.SetActive(true);
        Instance._title.text = title;
        Instance._tip.text = tip;

        Instance.StartCoroutine(monitor());

        IEnumerator monitor()
        {
            while (!loading.isDone)
            {
                Instance._progressBar.fillAmount = loading.progress;
                yield return null;
            }

            Debug.Log(title + "proccess reached to end");

            Instance._mainParent.gameObject.SetActive(false);
            Instance._title.text = string.Empty;
            Instance._tip.text = string.Empty;
        }
    }

    private static void CheckInstance()
    {
        if (Instance == null) throw new System.Exception("No LoadDisplay instance found. You need to create one");
    }

    private void Start()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
        DontDestroyOnLoad(this);
    }
}
