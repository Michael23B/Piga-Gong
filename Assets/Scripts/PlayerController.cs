using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    XboxController controls;
    private Vector2 move;
    Vector3 vectorMod = Vector3.zero;
    bool moveUp = false;
    bool moveDown = false;
    private bool isBoosting = false;
    private Vector2 gamepadRoation;
    
    private Rigidbody _rb;
    public float speed = 0f;
    public float boostMultiplier = 1f;
    public UnityEvent boosting;
    public GameObject playerCamera;
    private float _rightButtonCooler = 0.5f ;
    private float _rightButtonCount = 0;
    private float _leftButtonCooler = 0.5f ;
    private float _leftButtonCount = 0;
    public float mouseSensitivity = 1f;
    public bool useGamepad = false;
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        controls = new XboxController();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.Rotate.performed += ctx => gamepadRoation = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotate.canceled += ctx => gamepadRoation = Vector2.zero;
        controls.Gameplay.Boost.performed += ctx => isBoosting = true;
        controls.Gameplay.Boost.canceled += ctx => isBoosting = false;
        controls.Gameplay.Up.performed += ctx => moveUp = true;
        controls.Gameplay.Up.canceled += ctx => moveUp = false;
        controls.Gameplay.Down.performed += ctx => moveDown = true;
        controls.Gameplay.Down.canceled += ctx => moveDown = false;
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        var playerTransform = transform;
        var cameraTransform = playerCamera.transform;
        cameraTransform.position = playerTransform.position;
        cameraTransform.rotation = playerTransform.rotation;

        if (useGamepad)
        {
           
            if (move.y > 0 && isBoosting)
            {
                boosting.Invoke();
                vectorMod += transform.forward * (move.y * boostMultiplier);
            }
            else
            {
                vectorMod += transform.forward * move.y;
            }
            vectorMod += transform.right * move.x;
            if (moveUp)
            {
                vectorMod += transform.up;
            }
            
            if (moveDown)
            {
                vectorMod -= transform.up;
            }

        }
        else
        {
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
            if (Input.GetKey(KeyCode.LeftControl))
            {
                vectorMod -= transform.up;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                vectorMod += transform.up;
            }
        }
       
        _rb.velocity += vectorMod * (speed * Time.fixedDeltaTime);
        vectorMod = Vector3.zero;
    }

    private void Update()
    {
        var playerTransform = transform;

        if (useGamepad)
        {
            var yaw = Quaternion.Euler(0f, gamepadRoation.x * mouseSensitivity , 0f);
            var pitch = Quaternion.Euler(-gamepadRoation.y * mouseSensitivity , 0f, 0f);
            transform.rotation =  yaw * playerTransform.rotation * pitch; // yaw on the left && pitch on the right?
        }
        else
        {
            var yaw = Quaternion.Euler(0f, Input.GetAxis("Mouse X") * mouseSensitivity , 0f);
            var pitch = Quaternion.Euler(-Input.GetAxis("Mouse Y") * mouseSensitivity , 0f, 0f);
            transform.rotation =  yaw * playerTransform.rotation * pitch; // yaw on the left && pitch on the right?
        }
    }
}
