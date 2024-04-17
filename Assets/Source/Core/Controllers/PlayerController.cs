using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5.0f;

    [SerializeField]
    private FloatingJoystick _joystick;
    
    private PlayerController _player;
    private Vector3 _cameraOffsetPosition;
    private Rigidbody _rigidbody;
    private Animator _animator;

    //[SerializeField]
    //private GameObject _gameObjectSetup;

    private void Awake()
    {
        _player = this;

        _cameraOffsetPosition = Camera.main.transform.position;

        _rigidbody = _player.GetComponent<Rigidbody>();
        _animator = _player.GetComponent<Animator>();
    }

    private void Update()
    {
        _movePlayer();
    }

    private void _movePlayer()
    {
        bool isMoving = _joystick.Horizontal <= -0.25f || _joystick.Vertical <= -0.25f || _joystick.Horizontal >= 0.25f || _joystick.Vertical >= 0.25f;

        if (isMoving)
        {
            Vector3 velocity = new Vector3(_joystick.Horizontal, _rigidbody.velocity.y, _joystick.Vertical) * _moveSpeed;

            _rigidbody.velocity = velocity;
            _rigidbody.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _rigidbody.rotation = new Quaternion(0f, _rigidbody.rotation.y, 0f, _rigidbody.rotation.w);

            _moveCamera();
        }
        else
        {
            _rigidbody.velocity = new Vector3(0, 0, 0); ;
        }

        _animator.SetBool("IsRunning", isMoving);
    }

    private void _moveCamera()
    {
        Camera.main.transform.position = new Vector3(_player.transform.position.x + _cameraOffsetPosition.x, _cameraOffsetPosition.y, _player.transform.position.z + _cameraOffsetPosition.z);
    }
}
