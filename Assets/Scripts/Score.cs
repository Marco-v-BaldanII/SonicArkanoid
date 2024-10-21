using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI scoreLabel;

    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    
    public void AddPoints(int pts)
    {
        points += pts;
        scoreLabel.text = points.ToString();
    }

}
