using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();

    private void Awake()
    {
        stateMachine.SetState(STATE.PLAYING_STATE);
    }
    public void CallPause()
    {
        if (stateMachine.GetState() == STATE.PLAYING_STATE)
        {

            stateMachine.SetState(STATE.PAUSE_STATE);
        }
        else
        {
            stateMachine.SetState(STATE.PLAYING_STATE);
        }

        
    }
}
