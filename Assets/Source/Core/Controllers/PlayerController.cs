using UnityEngine;

namespace Assets.Source.Core.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed = 5.0f;

        [SerializeField]
        private FloatingJoystick _joystick;
    
        private PlayerController _player;
        private Vector3 _cameraOffsetPosition;
        private Vector3 _cameraRotation;
        private Rigidbody _rigidbody;
        private Animator _animator;

        private void Awake()
        {
            _player = this;

            _cameraOffsetPosition = Camera.main.transform.position;
            _cameraRotation = Camera.main.transform.rotation.eulerAngles;

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
                var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, _cameraRotation.y, 0));
            
                Vector3 vector = matrix.MultiplyPoint3x4(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));

                _rigidbody.velocity = vector * _moveSpeed;
                _rigidbody.rotation = Quaternion.LookRotation(_rigidbody.velocity);
                _rigidbody.rotation = new Quaternion(0f, _rigidbody.rotation.y, 0f, _rigidbody.rotation.w);

                _moveCamera();
            }
            else
            {
                _rigidbody.velocity = new Vector3(0, 0, 0);
            }

            _animator.SetBool("IsRunning", isMoving);
        }

        private void _moveCamera()
        {
            Camera.main.transform.position = new Vector3(_player.transform.position.x + _cameraOffsetPosition.x, _cameraOffsetPosition.y, _player.transform.position.z + _cameraOffsetPosition.z);
        }
    }
}
