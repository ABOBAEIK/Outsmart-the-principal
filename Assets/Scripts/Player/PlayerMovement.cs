using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedMultiple;

    private Rigidbody _rb;

    private Vector3 _movement;
    private Vector3 _input;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //_movement = (Input.GetAxis("Vertical") + Input.GetAxis("Run") * _speedMultiple) * transform.forward * _speed * Time.fixedDeltaTime;
        //_movement = ((runMultiple * Input.GetAxis("Vertical")) * transform.forward + (runMultiple * Input.GetAxis("Horizontal")) * transform.right) * _speed * Time.fixedDeltaTime;
        //_movement = (vertical * transform.forward + horizontal * transform.right)  * _speedMultiple * _speed * Time.fixedDeltaTime;

        _input = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, _playerCamera.eulerAngles.y, 0);

        if (Input.GetButton("Run"))
        {
            _movement = _input.normalized * _speed * _speedMultiple;
        }
        else
        {
            _movement = _input.normalized * _speed;
        }

        _rb.MovePosition(transform.position + _movement * Time.fixedDeltaTime);
    }
}
