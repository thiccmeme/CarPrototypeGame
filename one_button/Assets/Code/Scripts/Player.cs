using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     private GameManager _gameManager;

     [SerializeField]
     private GameOverMenu _gameOverMenu;

    public int pHealth;

    private Animation anim;
    
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        

    }
    
    private void FixedUpdate()
    {
        if (pHealth <= 0)
        {
            //die
            Debug.Log("ded");
            _gameOverMenu.HandleGameOver();
            Invoke("Re", 0.5f);
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

    private void Re()
    {
        
        //_gameManager.Restart();
    }
}
