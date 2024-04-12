using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {

    }

    [SerializeField]
    private float SPEED = 1.0f;
    private const float DELTA_TIME = 0.01f;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            Player.transform.Translate(DELTA_TIME * SPEED * Vector3.forward);

        if (Input.GetKey(KeyCode.A))
            Player.transform.Translate(DELTA_TIME * SPEED * Vector3.left);

        if (Input.GetKey(KeyCode.S))
            Player.transform.Translate(DELTA_TIME * SPEED * Vector3.back);

        if (Input.GetKey(KeyCode.D))
            Player.transform.Translate(DELTA_TIME * SPEED * Vector3.right);
    }
}
