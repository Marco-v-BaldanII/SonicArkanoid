using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreLabel;

    private int points = 0;


    [SerializeField] private SaveManager saveManager;


    // Start is called before the first frame update
    void Start()
    {
        points = MatchManager.instance.GetPoints();
        AddPoints(0);

        // When you win the match, sdn the points to be saved
        MatchManager.instance.winSignal += SendPoints;
        MatchManager.instance.loadSignal += LoadPoints;
        MatchManager.instance.savePointSignal += SendPoints;

    }

    // Update is called once per frame

    public void SendPoints()
    {
        MatchManager.instance.SavePoints(points);
    }
    
    public void AddPoints(int pts)
    {
        points += pts;
        scoreLabel.text = points.ToString();
    }

    public void LoadPoints(int pts) /* The saveManager will send the points */
    {
        points = pts;
        scoreLabel.text = points.ToString();
    }

    private void OnDestroy()
    {
        // Desusbrcribe from events
        MatchManager.instance.winSignal -= SendPoints;
        MatchManager.instance.loadSignal -= LoadPoints;
        MatchManager.instance.savePointSignal -= SendPoints;
    }


}
