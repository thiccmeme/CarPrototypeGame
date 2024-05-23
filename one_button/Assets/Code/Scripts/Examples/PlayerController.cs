using System;
using System.Collections;
using System.Collections.Generic;
using Guirao.UltimateTextDamage;
using Unity.Mathematics;
using UnityEngine;
/// <summary>
/// JumpBall implements IButtonlistener, an interface, which means that it has to implement those functions
/// </summary>
public class PlayerController : MonoBehaviour, IButtonListener
{
    [SerializeField] private float horizontalForce = 3f;
    [SerializeField] private float horizSpeedIncrease = 1f;
    [SerializeField] private float rotationSmoothness = 0.5f;
    [SerializeField] private Quaternion currentRotation;
    private Quaternion newAngle;
    [SerializeField] private Quaternion maxAngle = quaternion.Euler(0f, 0f, 45f);
    [SerializeField] private Quaternion minAngle = quaternion.Euler(0f, 0f, -45f);
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
        else
        {
            
            _rb.velocity = new Vector2(_rb.velocity.x + horizSpeedIncrease * Time.fixedDeltaTime, 0);
            
        }
        currentRotation = Quaternion.Slerp( currentRotation, newAngle, rotationSmoothness * Time.fixedDeltaTime); 
        _car.transform.localRotation = currentRotation;
    }

    public void ButtonHeld(ButtonInfo heldInfo)
    {
            //_rb.velocity = new Vector2(_rb.velocity.x + horizSpeedIncrease * Time.fixedDeltaTime, 0);
    }

    public void ButtonPressed(ButtonInfo pressedInfo)
    {
        _rb.velocity = new Vector2(_rb.velocity.x + (_rb.velocity.x / 2), 0);
        newAngle = minAngle;
        _currentButton = pressedInfo;
    }

    public void ButtonReleased(ButtonInfo releasedInfo)
    {
        _rb.velocity = new Vector2(_rb.velocity.x - (_rb.velocity.x / 2), 0);
        newAngle = maxAngle;
        _currentButton = releasedInfo;
    }

    private void UpdateCarRotation(Quaternion rotation)
    {
        _car.transform.localRotation = rotation;
    }
}