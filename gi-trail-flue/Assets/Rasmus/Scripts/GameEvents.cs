using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public void Awake()
    {
        current = this;
    }

    public event Action<List<string>> onNewLine;
    public void NewLine(List<string> path)
    {
        if (onNewLine != null) onNewLine(path);
    }

    public event Action<Level> onNewGame;
    public void NewGame(Level level)
    {
        if (onNewGame != null) onNewGame(level);
    }
}
