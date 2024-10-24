using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private SaveManager saveManager;
    private TextMeshProUGUI highScoreLabel;

    private void Awake()
    {
        highScoreLabel = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int score = saveManager.LoadHighScore();
        highScoreLabel.text = "Highscore: " + score.ToString();
    }

}