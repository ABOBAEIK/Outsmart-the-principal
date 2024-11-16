using UnityEngine;

public class SpatialExamAnswer : SpatialItem
{
    private SpatialItemTaker _currentTaker;

    private void Awake()
    {
        Name = "Ответ на билет экзамена";

        Mode = TakingMode.Taking;
    }

    public override void Taking(SpatialItemTaker whoTaking)
    {
        if (_currentTaker == null)
        {
            _currentTaker = whoTaking;
        }
        else if (whoTaking == _currentTaker)
        {
            CurrentWeight += Time.deltaTime;
            if (CurrentWeight > Weight - 0.01f)
            {
                whoTaking.OnTakingFinished(this);
                gameObject.SetActive(false);
                IsUsing = false;
            }
            else
            {
                IsUsing = true;
            }
        }
    }

    public override void StopTaking(SpatialItemTaker whoTakingStop)
    {
        _currentTaker = null;
        CurrentWeight = 0;
        IsUsing = false;
    }

    public override InventoryItem ToInventoryItem()
        => InventoryItem.GetInventoryItem(InventoryItemType.ExamAnswer);
}