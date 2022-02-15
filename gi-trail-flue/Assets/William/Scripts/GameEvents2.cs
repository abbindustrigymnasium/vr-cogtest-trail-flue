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

    public event Action<List<string>> onNewLine;
    public void NewLine(List<string> path)
    {
        if (onNewLine != null) onNewLine(path);
    }

    public event Action<List<string>> onNewGame;
    public void NewGame(List<string> path)
    {
        if (onNewLine != null) onNewGame(path);
    }
}
