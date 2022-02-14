using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignFluency : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onNewLine += OnNewLine;
    }

    void OnNewLine(List<string> path)
    {
        // TODO: Validation
        Debug.Log("Click");

        if (path.Count == 3)
        {
            Debug.Log("3");
        }
    }

    void OnDestroy()
    {
        GameEvents.current.onNewLine -= OnNewLine;
    }
}
