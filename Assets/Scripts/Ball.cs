using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public float startingXDirection;
    public float startingYDirection;

    void Start()
    {
        ResetPositionAndVelocity();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetPositionAndVelocity();
        }
    }

    private void ResetPositionAndVelocity()
    {
        transform.position = Vector3.zero;
        startingXDirection = Random.Range(0, 2) == 0 ? 1 : -1;
        startingYDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(0f, speed * startingYDirection, speed * startingXDirection);
    }
}
