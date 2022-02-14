using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignFluency : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onNewLine += OnNewLine;
    }

    void OnDestroy()
    {
        GameEvents.current.onNewLine -= OnNewLine;
    }

    void OnNewLine(List<string> path)
    {
        Debug.Log("Click: " + path[path.Count - 1]);

        // Full circle
        if (path.Count > 1 && path[0] == path[path.Count - 1])
        {
            // TODO: Validation

            // Game over
            GameEvents.current.NewGame();
        }
    }
}
