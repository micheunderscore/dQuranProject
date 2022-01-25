using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    void Awake() {
        Instance = this;
    }
    
    public void UpdateGameState(GameState newState) {
        State = newState;

        switch (newState) {
            case GameState.SelectColor:
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EnemyTurn:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState {
    SelectColor,
    PlayerTurn,
    EnemyTurn,
    Victory,
    Lose
}
