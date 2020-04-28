using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goals : MonoBehaviour
{
    public UnityEvent OnCollision;
    // Start is called before the first frame update

    
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
        {
            return;
        }

        // Fire the OnCollision event
        OnCollision?.Invoke();
    }
}
