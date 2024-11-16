using UnityEngine;
using UnityEngine.UI;

public class ItemInfoView : MonoBehaviour
{
    [Header("Item taking")]
    [SerializeField] private PlayerItemTaker _itemTaker;
    [SerializeField] private Image _fillBarImage;

    private void OnEnable()
    {
        _itemTaker.SubjectChanged += OnSubjectChanged;
        _itemTaker.SubjectUnfocused += OnSubjectUnfocused;

        _itemTaker.ItemTaking += OnItemTaking;
        _itemTaker.ItemTakingStopped += OnItemTakingStopped;
        _itemTaker.ItemTakingFinished += OnItemTakingFinished;
    }

    private void OnSubjectChanged(SpatialItem oldI, SpatialItem newI)
    {
        PlayerMessaging.SetText(newI.Name);
    }

    private void OnSubjectUnfocused(SpatialItem oldI)
    {
        PlayerMessaging.Clear();
    }

    private void OnItemTaking(SpatialItem item)
    {
        PlayerMessaging.SetText(item.Name + " is taking");

        _fillBarImage.fillAmount = item.CurrentWeight / item.Weight;

        Debug.Log(item.Name + " is taking");
    }

    private void OnItemTakingStopped(SpatialItem stopItem)
    {
        if (_itemTaker.Subject != null)
        {
            PlayerMessaging.SetText(_itemTaker.Subject.Name);
        }
        else
        {
            PlayerMessaging.Clear();
        }

        _fillBarImage.fillAmount = 0f;

        Debug.Log(stopItem.Name + " taking stopped");
    }

    private void OnItemTakingFinished(SpatialItem finishItem)
    {
        PlayerMessaging.Clear();

        _fillBarImage.fillAmount = 0f;

        Debug.Log(finishItem.Name + " taking finished");
    }

    private void OnDisable()
    {
        _itemTaker.SubjectChanged -= OnSubjectChanged;
        _itemTaker.SubjectUnfocused -= OnSubjectUnfocused;

        _itemTaker.ItemTaking -= OnItemTaking;
        _itemTaker.ItemTakingStopped -= OnItemTakingStopped;
        _itemTaker.ItemTakingFinished -= OnItemTakingFinished;
    }
}
