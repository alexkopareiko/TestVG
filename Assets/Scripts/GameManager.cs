using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Play,
    PlayerDied,
    Pause,
}

public class GameManager : MonoBehaviour
{
    private static GameManager s_Instance;

    public static GameManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                var singletonObject = new GameObject("GameManager");
                s_Instance = singletonObject.AddComponent<GameManager>();
                //DontDestroyOnLoad(singletonObject);
            }
            return s_Instance;
        }
    }

    private bool _isGamePaused;
    private int _level = 1;

    public int level => _level;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (s_Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // set target frame rate
        Application.targetFrameRate = 60;

        StartLevel();
    }

    public void PauseGame(bool value)
    {
        _isGamePaused = value;
        Time.timeScale = value ? 0 : 1;
    }


    private void StartLevel()
    {
        SpawnManager.Instance.SpawnEnemies();
    }


}