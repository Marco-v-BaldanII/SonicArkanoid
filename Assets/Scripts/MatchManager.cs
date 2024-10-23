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
    public event EventHandler looseSignal;

    public delegate void LoadEventHandler(int pts);
    public event LoadEventHandler loadSignal;

    public event EventHandler savePointSignal;

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
        looseSignal.Invoke();

        points = 0;
        SceneManager.LoadScene(1);
    }

    public void Win()
    {
        wonMatches++;
        winSignal.Invoke();


        SceneManager.LoadScene(3);
    }

    public void SavePoints(int points)
    {
        this.points = points;
        loadSignal?.Invoke(points);
    }

    public int GetPoints() 
    {
        savePointSignal?.Invoke();

        return this.points; 
    }

    public void RegisterSpawnBlock()
    {
        numBlocks++;
    }

    public void RegisterDestroyBlock()
    {
        numBlocks--;
        Debug.Log("num blocks " + numBlocks.ToString());
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

    public void StartNewGame(bool title_scrren = false)
    {
        loadBricks = false;
        if (title_scrren)
        {
            SceneManager.LoadScene(0);

        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
