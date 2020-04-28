using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public float startingXDirection;
    public float startingYDirection;
    public UnityEvent onReset;
    private Renderer _renderer;
    private Material _mat;
    private Rigidbody _rb;
    public Color player1Glow = Color.red;
    public Color player2Glow = Color.blue;
    private Color _currentPlayerGlow;
    
    void Start()
    {
        _renderer = GetComponent<Renderer> ();
        _mat = _renderer.material;
        _rb = GetComponent<Rigidbody>();
        ResetPositionAndVelocity();
        if (startingXDirection < 0)
        {
            _currentPlayerGlow = player2Glow;
        }
        else {
            _currentPlayerGlow = player1Glow;
        }
    }

    private void Update()
    {
        var finalColor = _currentPlayerGlow * Mathf.LinearToGammaSpace (Math.Abs(transform.position.z));
 
        _mat.SetColor ("_EmissionColor", finalColor);
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPositionAndVelocity();
            onReset?.Invoke();
        }
    }

    public void ResetPositionAndVelocity()
    {
        transform.position = Vector3.zero;
        startingXDirection = Random.Range(0, 2) == 0 ? 1 : -1;
        startingYDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().velocity = new Vector3(0f, speed * startingYDirection, speed * startingXDirection);
        if (startingXDirection < 0)
        {
            FindObjectOfType<TurnManager>().OnPlayer2Hit();
            _currentPlayerGlow = player2Glow;
        }
        else {
            FindObjectOfType<TurnManager>().OnPlayer1Hit();
            _currentPlayerGlow = player1Glow;
        }
    }

    public void SwitchColor()
    {
        if (_currentPlayerGlow == player1Glow)
        {
            _currentPlayerGlow = player2Glow;
        }
        else
        {
            _currentPlayerGlow = player1Glow;
        }
    }
}
