using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlingmentManager : MonoBehaviour
{
    [SerializeField] GameObject horizontalCanvas;
    [SerializeField] GameObject verticalCanvas;

    public Paddle paddle;

    public enum Orientation
    {
        PORTRAIT,
        LANDSCAPE,
    }

    public Orientation orientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MatchManager.instance.IsPaused()) { return; }
        
        if (Screen.width > Screen.height)
        {
            horizontalCanvas.SetActive(true);
            verticalCanvas.SetActive(false);
            orientation = Orientation.LANDSCAPE;
            paddle?.ChangeOritentation(orientation);


            Time.timeScale = 1.8f;
        }
        else
        {
            verticalCanvas.SetActive(true);
            horizontalCanvas.SetActive(false);
            orientation = Orientation.PORTRAIT;
            paddle?.ChangeOritentation(orientation);

            Time.timeScale = 1.0f;
        }

    }
}
