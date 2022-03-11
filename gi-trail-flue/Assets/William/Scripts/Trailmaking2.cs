using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailmaking2 : MonoBehaviour
{

    public static float time = 10;
    public float timeRemaining = 10000000;
    public bool gameOver = false;

    private List<string> order = new List<string>()
    {
        "Sphere0_textDecal",
        "Sphere1_textDecal",
        "Sphere2_textDecal",
        "Sphere3_textDecal",
        "Sphere4_textDecal",
        "Sphere5_textDecal",
    };

    private int corrects = 0;
    private int wrongs = 0;

    void Start()
    {
        GameEvents2.current.onNewLine += OnNewLine;
        GameEvents2.current.onNewGame += OnNewGame;
        GameEvents2.current.onGameDone += OnGameDone;
        GameEvents2.current.onInstructionDone += OnInstructionDone;
        timeRemaining = 10000000;
    }

    void OnNewLine(List<string> path, int sphereTime)
    {
        // TODO: Validation

        if (GameObject.Find(path[path.Count-1]).tag == "end")
        {
            GameEvents2.current.NewGame(path, sphereTime);
            // GameEvents2.current.NewMode();
        }
    }

    void OnNewGame(List<string> path, int sphereTime)
    {
        validate(path, order, sphereTime);
        // onEnd();
    }

    void OnGameDone()
    {
        gameOver = true;
    }

    void OnInstructionDone()
    {
        timeRemaining = 10;
    }

    private bool validate1A(List<string> path, List<string> order)
    {
        if (string.Join("", path.ToArray()) == string.Join("", order.ToArray()))
        {
            corrects += 1;
            return true;
        }
        else
        {
            wrongs += 1;
            return false;
        }
    }

    private bool validate(List<string> path, List<string> order, int sphereTime)
    {
        if (sphereTime == 0)
        {
            return validate1A(path, order);
        }
        else if (sphereTime == 1)
        {
            return validate1A(path, order);
        }
        else if (sphereTime == 2)
        {
            return validate1A(path, order);
        }
        else
        {
            return false;
        }
    }

    // private void onEnd()
    // {
    //     GameObject[] lines = GameObject.FindGameObjectsWithTag("line");

    //     foreach (GameObject line in lines)
    //     {
    //         Destroy(line);
    //     }

    //     // Reset variables

    // }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 1000000;
            if (!gameOver)
            {
                GameEvents2.current.NewMode();
            }
        }
    }

    void OnDestroy()
    {
        GameEvents2.current.onNewLine -= OnNewLine;
        GameEvents2.current.onNewGame -= OnNewGame;
        GameEvents2.current.onGameDone -= OnGameDone;
        GameEvents2.current.onInstructionDone -= OnInstructionDone;
    }
}
