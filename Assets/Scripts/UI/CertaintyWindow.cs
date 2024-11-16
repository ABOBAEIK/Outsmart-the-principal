using System;
using UnityEngine;
using UnityEngine.UI;

public class CertaintyWindow : MonoBehaviour
{
    public static CertaintyWindow Instance { get; private set; }

    [SerializeField] private Transform _mainParent;

    [SerializeField] private Button _yes;
    [SerializeField] private Button _no;

    private Action<CertaintyAnswer> _onAnswerGot;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void Request(Action<CertaintyAnswer> onAnswerGot)
    {
        _mainParent.gameObject.SetActive(true);

        _onAnswerGot = onAnswerGot;

        _yes.onClick.AddListener(() => GiveAnswer(CertaintyAnswer.Yes));
        _no.onClick.AddListener(() => GiveAnswer(CertaintyAnswer.No));
    }

    private void GiveAnswer(CertaintyAnswer answer)
    {
        _onAnswerGot(answer);

        ResetTo();

        Debug.Log("Got answer: " + answer);
    }

    private void ResetTo()
    {
        _yes.onClick.RemoveAllListeners();
        _no.onClick.RemoveAllListeners();

        _mainParent.gameObject.SetActive(false);
    }
}