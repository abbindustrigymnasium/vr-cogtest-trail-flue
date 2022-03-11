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
            new Sphere(7, 60, 90, "light", "1"),
            new Sphere(7, 70, 80, "dark", "A"),
            new Sphere(7, 80, 85, "light", "2"),
            new Sphere(7, 90, 80, "dark", "B"),
            new Sphere(7, 100, 90, "light", "3")
        }),
        new Level(new List<Sphere>() {
            new Sphere(7, 60, 90, "dark", "1"),
            new Sphere(7, 70, 80, "light", "A"),
            new Sphere(7, 80, 85, "dark", "2"),
            new Sphere(7, 90, 80, "light", "B"),
            new Sphere(7, 100, 90, "dark", "3")
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
