using UnityEngine;
using UnityEngine.Events;

public class Bumper : MonoBehaviour
{
    public bool isBump1;
    public float speed = 5f;
    public float ballReflectSpeedMultiplier = 100f;
    public UnityEvent OnCollision;
    private Collider bumperCollider;

    private void Start()
    {
        bumperCollider = GetComponent<Collider>();
    }

    // void FixedUpdate()
    // {
    //     string verticalAxis = isBump1 ? "Vertical" : "Vertical2";
    //     string horizontalAxis = isBump1 ? "Horizontal" : "Horizontal2";
    //
    //     transform.Translate(0f, Input.GetAxis(verticalAxis) * speed * Time.fixedDeltaTime, Input.GetAxis(horizontalAxis) * speed * Time.fixedDeltaTime);
    // }

    private void OnCollisionExit(Collision collision)
    {
        // Add force to reflect the ball in the direction from where we hit it
        if (collision.collider.GetComponent<Ball>()) {
            Collider ballCollider = collision.collider;
            Vector3 direction = ballCollider.transform.position - transform.position;

            ballCollider.GetComponent<Rigidbody>().AddForce(direction * ballReflectSpeedMultiplier);
        }

        // Fire the OnCollision event
        OnCollision?.Invoke();
    }
}
