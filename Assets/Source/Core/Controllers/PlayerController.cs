using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5.0f;

    [SerializeField]
    private DynamicJoystick _joystick;
    
    private PlayerController _player;
    private Vector3 _cameraOffset;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _player = this;
        _cameraOffset = Camera.main.transform.position;
        _rigidbody = _player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(_joystick.Horizontal, _rigidbody.velocity.y, _joystick.Vertical) * _moveSpeed;

        _rigidbody.velocity = velocity;

        Camera.main.transform.position = new Vector3(_player.transform.position.x + _cameraOffset.x, _cameraOffset.y, _player.transform.position.z + _cameraOffset.z);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _rigidbody.rotation = Quaternion.LookRotation(-_rigidbody.velocity);
            _rigidbody.rotation = new Quaternion(0, _rigidbody.rotation.y, 0, _rigidbody.rotation.w);
        }
    }
}
