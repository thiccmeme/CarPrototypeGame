using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private String _scene;
    private Obstacle _obstacle;
    #region Restart
    public void Restart()
    {
        SceneManager.LoadScene(_scene);
        Time.timeScale = 1.0f;
        _obstacle._speed = _obstacle._defaultSpeed;

    }

    private void Awake()
    {
        _obstacle = FindObjectOfType<Obstacle>();
    }

    #endregion
}