using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enum GameMode
// {
//     Basic,
//     Filter,
//     Switch
// }

public class DesignFluency : MonoBehaviour
{
    List<Level> levels = new List<Level>(){
        new Level(new List<Sphere>() {
            new Sphere(7, 60, 90, "light", ""),
            new Sphere(7, 70, 80, "dark", ""),
            new Sphere(7, 80, 85, "light", ""),
            new Sphere(7, 90, 80, "dark", ""),
            new Sphere(7, 100, 90, "light", "")
        }),
        new Level(new List<Sphere>() {
            new Sphere(7, 60, 80, "dark", ""),
            new Sphere(7, 70, 90, "light", ""),
            new Sphere(7, 80, 80, "dark", ""),
            new Sphere(7, 90, 90, "light", ""),
            new Sphere(7, 100, 80, "dark", "")
        })
    };

    // GameMode gameMode = GameMode.Basic;
    int level = 0;

    void Start()
    {
        GameEvents.current.onNewLine += OnNewLine;
        GameEvents.current.NewGame(levels[0]);
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
            Debug.Log("Level complete");

            // TODO: Svae data

            // Game over
            level++;
            GameEvents.current.NewGame(levels[level]);
        }
    }
}
