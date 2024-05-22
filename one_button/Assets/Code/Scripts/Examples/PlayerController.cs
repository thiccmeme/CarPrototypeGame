using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
/// <summary>
/// JumpBall implements IButtonlistener, an interface, which means that it has to implement those functions
/// </summary>
public class PlayerController : MonoBehaviour, IButtonListener
{
    [SerializeField] private float horizontalForce = 3f;
    [SerializeField] private float horizSpeedIncrease = 1f;
    private float currentRotation = 0f;
    private float newRotation = 0f;
    private float lastKnownRotation = 0f;
    [SerializeField] private float rotationSmoothness = 0.5f;
    private Rigidbody2D _rb;
    private ButtonInfo _currentButton;
    private GameObject _car;
    
    private PlayerInputs inputObject;
    
    void Awake()
    {
        _currentButton.CurrentState = ButtonState.Released;
        _rb = GetComponent<Rigidbody2D>();
        _car = GameObject.Find("Car");
        var inputObject = FindObjectOfType<PlayerInputs>();
        inputObject.RegisterListener(this);
        _rb.velocity = new Vector2(0, -horizontalForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_currentButton.CurrentState == ButtonState.Released)
        {
            _rb.velocity = new Vector2(_rb.velocity.x - horizSpeedIncrease * Time.fixedDeltaTime, 0);
        }
        currentRotation = Mathf.Clamp(Mathf.Lerp(lastKnownRotation, newRotation, rotationSmoothness), -45f, 45f);
        UpdateCarRotation(currentRotation);
    }

    public void ButtonHeld(ButtonInfo heldInfo)
    {
            _rb.velocity = new Vector2(_rb.velocity.x + horizSpeedIncrease * Time.fixedDeltaTime, 0);
    }

    public void ButtonPressed(ButtonInfo pressedInfo)
    {
        _rb.velocity = new Vector2(_rb.velocity.x + (_rb.velocity.x / 2), 0);
        lastKnownRotation = currentRotation;
        newRotation = -45f;
        _currentButton = pressedInfo;
    }

    public void ButtonReleased(ButtonInfo releasedInfo)
    {
        _rb.velocity = new Vector2(_rb.velocity.x - (_rb.velocity.x / 2), 0);
        lastKnownRotation = currentRotation;
        newRotation = 45f;
        _currentButton = releasedInfo;
    }

    private void UpdateCarRotation(float rotation)
    {
        _car.transform.Rotate(0f, 0f, rotation);
    }
}