using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Mouse")]
    [SerializeField] private float _mouseYMax;
    [SerializeField] private float _mouseYMin;

    [SerializeField] private float _sensetivity;

    private Vector3 _rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * _sensetivity;

        _rotation.x -= mouseY;
        _rotation.x = Mathf.Clamp(_rotation.x, _mouseYMin, _mouseYMax);

        _rotation.y += mouseX;

        transform.rotation = Quaternion.Euler(_rotation);
    }
}
