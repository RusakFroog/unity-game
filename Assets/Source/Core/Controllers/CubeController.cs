using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject Cube;

    private void Start()
    {

    }

    [SerializeField]
    private const float SPEED = 1.0f;
    private const float DELTA_TIME = 0.01f;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            Cube.transform.Translate(DELTA_TIME * SPEED * Vector3.forward);

        if (Input.GetKey(KeyCode.A))
            Cube.transform.Translate(DELTA_TIME * SPEED * Vector3.left);

        if (Input.GetKey(KeyCode.S))
            Cube.transform.Translate(DELTA_TIME * SPEED * Vector3.back);

        if (Input.GetKey(KeyCode.D))
            Cube.transform.Translate(DELTA_TIME * SPEED * Vector3.right);
    }
}
