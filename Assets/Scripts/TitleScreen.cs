using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Button continueBtn;

    // Start is called before the first frame update
    void Start()
    {

        if (! saveManager.SaveExists())
        {
            continueBtn.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Continue()
    {
        MatchManager.instance.StartSavedGame();
    }

    public void NewGame()
    {
        MatchManager.instance.SavePoints(0);
        MatchManager.instance.StartNewGame(true);
    }

}
