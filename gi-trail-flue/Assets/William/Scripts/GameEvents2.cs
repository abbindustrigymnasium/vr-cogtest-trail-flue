using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents2 : MonoBehaviour
{
    public static GameEvents2 current;

    public void Awake()
    {
        current = this;
    }

    public event Action<List<string>, int> onNewLine;
    public void NewLine(List<string> path, int sphereTime)
    {
        if (onNewLine != null) onNewLine(path, sphereTime);
    }

    public event Action<List<string>, int> onNewGame;
    public void NewGame(List<string> path, int sphereTime)
    {
        if (onNewGame != null) onNewGame(path, sphereTime);
    }

    public event Action onNewMode;
    public void NewMode()
    {
        if (onNewMode != null) onNewMode();
    }

    public event Action onGameDone;
    public void GameDone()
    {
        if (onGameDone != null) onGameDone();
    }
}
