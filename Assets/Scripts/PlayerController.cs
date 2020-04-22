using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed = 0f;
    public float boostMultiplier = 1f;
    public UnityEvent boosting;
    private float _rightButtonCooler = 0.5f ;
    private float _rightButtonCount = 0;
    private float _leftButtonCooler = 0.5f ;
    private float _leftButtonCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        var vectorMod = new Vector3(0,0,0);
        
        if (Input.GetKey(KeyCode.W) )
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                boosting.Invoke();
                vectorMod += transform.forward * boostMultiplier;
            }
            else
            {
                vectorMod += transform.forward;
            }
        } 
        if (Input.GetKey(KeyCode.S))
        {
            vectorMod -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vectorMod -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vectorMod += transform.right;
        }
        _rb.velocity += vectorMod * (speed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        var vectorMod = new Vector3(0,0,0);
        
        // Double Tap Logic
        if ( Input.GetKeyDown(KeyCode.D)  &&  !(Input.GetKey(KeyCode.LeftShift))){
 
            if ( _rightButtonCooler > 0 && _rightButtonCount == 1/*Number of Taps you want Minus One*/){
                boosting.Invoke();
                vectorMod += transform.right * (boostMultiplier * 15);
            }else{
                _rightButtonCooler = 0.5f ; 
                _rightButtonCount += 1 ;
            }
        }
 
        if ( _rightButtonCooler > 0 )
        {
 
            _rightButtonCooler -= 1 * Time.deltaTime ;
 
        }else{
            _rightButtonCount = 0 ;
        }
        
        if ( Input.GetKeyDown(KeyCode.A) && !(Input.GetKey(KeyCode.LeftShift))){
 
            if ( _leftButtonCooler > 0 && _leftButtonCount == 1/*Number of Taps you want Minus One*/){
                boosting.Invoke();
                vectorMod -= transform.right * (boostMultiplier * 15);
            }else{
                _leftButtonCooler = 0.5f ; 
                _leftButtonCount += 1 ;
            }
        }
 
        if ( _leftButtonCooler > 0 )
        {
 
            _leftButtonCooler -= 1 * Time.deltaTime ;
 
        }else{
            _leftButtonCount = 0 ;
        }

        _rb.velocity += vectorMod * (speed * Time.deltaTime);
    }
}
