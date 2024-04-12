using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float SPEED = 1.0f;
    
    private const float DELTA_TIME = 0.01f;
    
    private PlayerController _player;
    private Camera _mainCamera;
    private Vector3 _cameraOffset;

    private readonly Dictionary<KeyCode, Vector3> _keysForwarding = new Dictionary<KeyCode, Vector3>
    {
        { KeyCode.W, Vector3.forward },
        { KeyCode.A, Vector3.left },
        { KeyCode.S, Vector3.back },
        { KeyCode.D, Vector3.right }
    };

    private void Awake()
    {
        _player = this;
        _mainCamera = Camera.main;
        _cameraOffset = _mainCamera.transform.position;
    }

    private void FixedUpdate()
    {
        // Move player and camera
        foreach (var pair in _keysForwarding)
        {
            if (Input.GetKey(pair.Key))
            {

                this.

                _player.transform.Translate(DELTA_TIME * SPEED * pair.Value);

                _mainCamera.transform.position = new Vector3(_player.transform.position.x + _cameraOffset.x, _cameraOffset.y, _player.transform.position.z + _cameraOffset.z);
            }
        }
    }
}
