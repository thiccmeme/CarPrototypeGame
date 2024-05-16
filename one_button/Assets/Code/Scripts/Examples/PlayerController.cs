using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// JumpBall implements IButtonlistener, an interface, which means that it has to implement those functions
/// </summary>
public class PlayerController : MonoBehaviour, IButtonListener
{
    [SerializeField] private float horizontalForce = 3f;
    [SerializeField] private float horizSpeedIncrease = 1f;
    private Rigidbody2D _rb;
    private ButtonInfo _currentButton;
    
    private PlayerInputs inputObject;
    
    void Awake()
    {
        _currentButton.CurrentState = ButtonState.Released;
        _rb = GetComponent<Rigidbody2D>();
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
    }

    public void ButtonHeld(ButtonInfo heldInfo)
    {
            _rb.velocity = new Vector2(_rb.velocity.x + horizSpeedIncrease * Time.fixedDeltaTime, 0);
        
    }

    public void ButtonPressed(ButtonInfo pressedInfo)
    {
        _rb.velocity = new Vector2(_rb.velocity.x + horizontalForce, 0);
        _currentButton = pressedInfo;
    }

    public void ButtonReleased(ButtonInfo releasedInfo)
    {
        _rb.velocity = new Vector2(0, 0);
        _currentButton = releasedInfo;
    }
}