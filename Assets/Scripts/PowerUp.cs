using UnityEngine;
using UnityEngine.Events;

// Calls the event that is assigned when picked up by the player, then destroys itself. The event should probably be one of its own functions.
public class PowerUp : MonoBehaviour
{
    public GameObject particleEffect;
    public UnityEvent whenPickedUpEvent;
    private Ball ball;

    public void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    public void YeetTheBall()
    {
        Vector3 explosionPosition = ball.transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));

        // Create the particle effect at the explosion position and destroy it after 2 seconds
        GameObject explosionGO = Instantiate(particleEffect, explosionPosition, Quaternion.identity);
        Destroy(explosionGO, 2f);
        // Apply explosion force at the explosion position
        ball.GetComponent<Rigidbody>().AddExplosionForce(1000, explosionPosition, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only trigger when a player picks up the powerup
        if (other.CompareTag("Player"))
        {
            whenPickedUpEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
