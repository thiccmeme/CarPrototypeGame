using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Guirao.UltimateTextDamage;
using UnityEngine;

public class Player : MonoBehaviour
{
     private GameManager _gameManager;

     [SerializeField]
     private GameOverMenu _gameOverMenu;

     [SerializeField] private float _invulnerabilityTime = 3f;

     private GameObject _car;

    private GameManager _gameManager;
    public int pScore;
    public int pHealth;
    public TextDamageClickerChaotic TextDamage;
    
    private Animation anim;


    public AudioClip Crash;
    public AudioClip Collect;


    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _car = GameObject.Find("Car");
    }

    private void Start()
    {
        TextDamage = FindObjectOfType<TextDamageClickerChaotic>();
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

    public void ObstacleAudio()
    {
        AudioSource collectableAudio = GetComponent<AudioSource>();
        if (collectableAudio != null)
        {
            collectableAudio.clip = Crash;
            collectableAudio.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource found on the collectable.");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            TextDamage.CollideObstacle();
            pHealth--;
            StartCoroutine(PainFlash());
            ObstacleAudio();
            Debug.Log(pHealth);
        }
        else if (col.gameObject.tag == "Collectable")
        {
            TextDamage.CollideCollectable();
            pScore++;

            // Find the AudioSource component and play the audio clip
            AudioSource collectableAudio = GetComponent<AudioSource>();
            if (collectableAudio != null)
            {
                collectableAudio.clip = Collect;
                collectableAudio.Play();
            }
            else
            {
                Debug.LogWarning("No AudioSource found on the collectable.");
            }

            // Optionally, you might want to destroy the collectable after collecting it
            Destroy(col.gameObject);
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