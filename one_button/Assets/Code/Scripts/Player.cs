using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     private GameManager _gameManager;

    public int pHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (pHealth <= 0)
        {
            //die
            Debug.Log("ded");
            _gameManager.Restart();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            pHealth--;
            Debug.Log(pHealth);
        }
    }
}
