using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Player : MonoBehaviour
{
     private GameManager _gameManager;

     [SerializeField]
     private GameOverMenu _gameOverMenu;

     [SerializeField] private float _invulnerabilityTime = 3f;

     private GameObject _car;

    public int pHealth;

    private Animation anim;
    
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _car = GameObject.Find("Car");
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
            StartCoroutine(PainFlash());
            Debug.Log(pHealth);
        }
    }

    private void Re()
    {
        
        //_gameManager.Restart();
    }

    IEnumerator PainFlash()
    {
        Color alpha = _car.GetComponent<SpriteRenderer>().color;
        alpha.a = 0.5f;
        _car.GetComponent<SpriteRenderer>().color = alpha;
        _car.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("hit");
        yield return new WaitForSeconds(_invulnerabilityTime);
        alpha.a = 1.0f;
        _car.GetComponent<BoxCollider2D>().enabled = true;
        _car.GetComponent<SpriteRenderer>().color = alpha;
        Debug.Log("finished");
    }
}
