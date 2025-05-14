using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Setup,
    Match,
    InMenu
}

public class StateManager : Singleton<StateManager>
{
    public GameState gameState { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.DoShowUpgradeUI += () => ChangeState(GameState.InMenu);
        GameEvents.OnUpgrade += () => ChangeState(GameState.Match);
        ChangeState(GameState.Match);
    }

    public void ChangeState(GameState state)
    {
        gameState = state;
        switch (state)
        {
            case GameState.Setup:
            case GameState.Match:
            case GameState.InMenu:
                break;
        }
    }
}
