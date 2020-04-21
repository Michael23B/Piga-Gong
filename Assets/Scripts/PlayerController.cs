using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cm1;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var xVelMod = 0;
        var yVelMod = 0;
        var zVelMod = 0;
        var VectorMod = new Vector3(0,0,0);
        
        if (Input.GetKey(KeyCode.W))
        {
            VectorMod += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            VectorMod -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            VectorMod -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            VectorMod += transform.right;
        }

        rb.velocity += VectorMod*speed;
    }
}
