using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClearScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("TransitionLevel", 1);
    }

    private void TransitionLevel()
    {
        SceneManager.LoadScene(0);
    }

}
