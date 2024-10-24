using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState :  StateInterface
{
    public void OnEnter()
    {
        MatchManager.instance.Pause();
    }
    public void DoUpdate() {; }

    public void OnExit()
    {
        MatchManager.instance.Pause();
    }

}
