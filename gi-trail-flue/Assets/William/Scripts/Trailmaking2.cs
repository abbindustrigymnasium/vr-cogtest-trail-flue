using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailmaking2 : MonoBehaviour
{

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
    }

    void OnNewLine(List<string> path)
    {
        // TODO: Validation
        Debug.Log("Click");

        if (path.Count == 3)
        {
            Debug.Log("3");
        }
        if (GameObject.Find(path[path.Count-1]).tag == "end")
        {
            Debug.Log("Yuh");
            GameEvents2.current.NewGame(path);
        }
    }

    void OnNewGame(List<string> path)
    {
        Debug.Log("NewGame!!");
        validate(path, order);
        // onEnd();
    }

    private bool validate(List<string> path, List<string> order)
    {
        if (string.Join("", path.ToArray()) == string.Join("", order.ToArray()))
        {
            corrects += 1;
            //path.ForEach(x=>Debug.Log(x + " "));
            Debug.Log(corrects);
            Debug.Log(wrongs);
            return true;
        }
        else
        {
            wrongs += 1;
            //path.ForEach(x=>Debug.Log(x + " "));
            Debug.Log(corrects);
            Debug.Log(wrongs);
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

    void OnDestroy()
    {
        GameEvents2.current.onNewLine -= OnNewLine;
        GameEvents2.current.onNewGame -= OnNewGame;
    }
}
