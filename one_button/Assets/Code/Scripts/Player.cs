using System;
using System.Collections;
using System.Collections.Generic;
using Guirao.UltimateTextDamage;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        _gameManager.Restart();
    }
}