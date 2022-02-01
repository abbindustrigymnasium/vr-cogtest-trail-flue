using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailmakingLineWS : MonoBehaviour
{

    public Camera cam;
    public Material myMat;
    private List<string> path = new List<string>();
    private List<string> pairs = new List<string>();
    private List<string> order = new List<string>()
    {
        "Sphere (6)",
        "Sphere",
        "Sphere (5)",
        "Sphere (4)",
        "Sphere (2)",
        "Sphere (1)",
        "Sphere (3)",
        "Sphere (7)"
    };
    private int corrects = 0;
    private int wrongs = 0;
    private string s1;
    private string s2 = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                string name = hit.collider.gameObject.name;
                string tag = hit.collider.gameObject.tag;
                // Debug.Log(name);
                if (!(s2==name))
                {
                    string pair1 = s2 + name;
                    string pair2 = name + s2;
                    if (!(pairs.Contains(pair1)) && !(pairs.Contains(pair2)))
                    {
                        s1 = s2;
                        s2 = name;
                        path.Add(s2);
                        // Debug.Log(path);
                        if (!string.IsNullOrEmpty(s1))
                        {   
                            pairs.Add(pair1);
                            drawLine(s1, s2);
                            if (tag == "end")
                            {
                                onEnd();
                            }
                        }
                    }
                }
            }
        }
    }

    private void drawLine(string s1, string s2)
    {
        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();

        go.name = "Line";
        go.tag = "line";

        lr.material = myMat;

        lr.material.color = new Color(1,1,1);

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
 
        var gun = GameObject.Find(s1);
        var projectile = GameObject.Find(s2);
 
        lr.SetPosition(0, gun.transform.position);
        lr.SetPosition(1, projectile.transform.position);
    }

    private void onEnd()
    {
        validate();
        GameObject[] lines = GameObject.FindGameObjectsWithTag("line");
        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
        // Reset variables
        s1 = "";
        s2 = "";
        path = new List<string>();
        pairs = new List<string>();
    }

    private bool validate()
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
}
