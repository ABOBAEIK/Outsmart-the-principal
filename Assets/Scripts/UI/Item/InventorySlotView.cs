using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Text _name;
    [SerializeField] private Text _count;

    public void SetInfo(InventoryItem item, int count)
    {
        _name.text = item.Name;
        _count.text = count.ToString();

        if (item.Icon == null)
        {
            _image.sprite = null;
            _image.color = Color.clear;
        }
        else
        {
            _image.sprite = item.Icon;
            _image.color = new Color(1f, 1f, 1f, 0.25f);
        }
    }
}
