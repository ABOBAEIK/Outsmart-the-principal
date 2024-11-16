using System;
using UnityEngine;

public abstract class SpatialItemTaker : MonoBehaviour
{
    /// <summary>
    /// Invokes when subject chaged. First argument is old item, second is new item
    /// </summary>
    public event Action<SpatialItem, SpatialItem> SubjectChanged;
    /// <summary>
    /// Invokes when subject assigned null. First argument is old item
    /// </summary>
    public event Action<SpatialItem> SubjectUnfocused;

    public Transform Head;
    public float TakeDistance;

    public LayerMask ItemMask;

    public SpatialItem Subject { get; protected set; }

    protected virtual void Update()
    {
        if (Physics.Linecast(Head.position, Head.position + Head.forward * TakeDistance, out RaycastHit hitInfo, ItemMask))
        {
            if (Subject == null || hitInfo.transform != Subject.transform)
            {
                SpatialItem oldSubject = Subject;

                Subject = hitInfo.transform.GetComponent<SpatialItem>();

                SubjectChanged?.Invoke(oldSubject, Subject);
            }
        }
        else if(Subject != null)
        {
            SpatialItem oldSubject = Subject;

            Subject = null;

            SubjectUnfocused?.Invoke(oldSubject);
        }
    }

    public abstract void OnTakingFinished(SpatialItem item);
}