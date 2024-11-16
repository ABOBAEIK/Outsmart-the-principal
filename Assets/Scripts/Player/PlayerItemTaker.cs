using System;
using UnityEngine;

public class PlayerItemTaker : SpatialItemTaker
{
    public event Action<SpatialItem> ItemTaking;
    public event Action<SpatialItem> ItemTakingStopped;
    public event Action<SpatialItem> ItemTakingFinished;

    private SpatialItem _takingItem;

    private void OnEnable()
    {
        SubjectUnfocused += OnSubjectUnfocused;
        SubjectChanged += OnSubjectChanged;
    }

    private void OnDisable()
    {
        SubjectUnfocused -= OnSubjectUnfocused;
        SubjectChanged -= OnSubjectChanged;
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButton(0))
        {
            if (_takingItem == null)
            {
                _takingItem = Subject;
            }
            else
            {
                ItemTaking?.Invoke(_takingItem);

                _takingItem.Taking(this);
            }
        }
        else if (_takingItem != null && Input.GetMouseButtonUp(0))
        {
            StopTakingItem(_takingItem);
        }
    }

    public override void OnTakingFinished(SpatialItem item)
    {
        ItemTakingFinished?.Invoke(item);
    }

    private void StopTakingItem(SpatialItem stopItem)
    {
        stopItem.StopTaking(this);

        ItemTakingStopped?.Invoke(stopItem);
    }

    private void OnSubjectUnfocused(SpatialItem unfocusedItem)
    {
        SpatialItem oldItem = _takingItem;
        _takingItem = null;
        if (oldItem != null && oldItem.IsUsing)
        {
            StopTakingItem(oldItem);
        }
    }

    private void OnSubjectChanged(SpatialItem oldItem, SpatialItem newItem)
    {
        _takingItem = newItem;
        if (oldItem != null && oldItem.IsUsing)
        {
            StopTakingItem(oldItem);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Head.position, Head.position + Head.forward * TakeDistance);
    }
}