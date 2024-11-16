using UnityEngine;

public abstract class SpatialItem : MonoBehaviour
{
    [field: SerializeField] public string Name {  get; protected set; }

    [field: SerializeField] public float Weight {  get; protected set; }

    [field: SerializeField] public bool IsUsing {  get; protected set; }

    public float CurrentWeight { get; protected set; }

    public TakingMode Mode { get; protected set; }

    public abstract void Taking(SpatialItemTaker whoTaking);

    public abstract void StopTaking(SpatialItemTaker whoStopTaking);

    public abstract InventoryItem ToInventoryItem();
}