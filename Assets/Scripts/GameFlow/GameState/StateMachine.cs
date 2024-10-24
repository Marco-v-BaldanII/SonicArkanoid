using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    PAUSE_STATE,
    PLAYING_STATE
}

public class StateMachine
{
    private StateInterface current_state;

    public void SetState(STATE newState)
    {
        current_state?.OnExit();

        switch (newState)
        {
            case STATE.PAUSE_STATE:
                current_state = new PauseState();
                break;
            case STATE.PLAYING_STATE:
                current_state = new PlayingState();
                break;
            default:
                break;

        }

        current_state?.OnEnter();

    }

    public STATE GetState()
    {
        if (current_state is PauseState)
        {
            return STATE.PAUSE_STATE;
        }
        else if (current_state is PlayingState)
        {
            return STATE.PLAYING_STATE;
        }

        return STATE.PLAYING_STATE;
    }

    // Update is called once per frame
    void Update()
    {
        current_state?.DoUpdate();
    }
}
