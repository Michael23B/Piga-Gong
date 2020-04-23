using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBoundaries : MonoBehaviour
{

    public GameObject bmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = bmp.transform.position;
    }
}
