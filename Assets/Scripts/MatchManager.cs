using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{

    public static MatchManager instance;

    private int wonMatches = 0;

    private int numBlocks = 0;

    private int points = 0;

    public delegate void  EventHandler();

    public event EventHandler winSignal;

    public bool loadBricks = false;
    public int GetMatchesWon() { return wonMatches; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Loose()
    {
        SceneManager.LoadScene(1);
    }

    public void Win()
    {
        wonMatches++;
        winSignal.Invoke();


        SceneManager.LoadScene(0);
    }

    public void SavePoints(int points)
    {
        this.points = points;
    }

    public int GetPoints() { return this.points; }

    public void RegisterSpawnBlock()
    {
        numBlocks++;
    }

    public void RegisterDestroyBlock()
    {
        numBlocks--;
        if (numBlocks <= 0)
        {
            Win();
        }
    }
    private float scale;
    private bool paused;

    public bool IsPaused()
    {
        return paused;
    }
    public void Pause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {

        }
    }

    public void StartSavedGame()
    {
        loadBricks = true;
        SceneManager.LoadScene(0);
    }

    public void StartNewGame()
    {
        loadBricks = false;
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }

}
