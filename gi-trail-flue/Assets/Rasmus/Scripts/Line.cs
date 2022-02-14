using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Camera cam;
    public Material myMat;

    public List<string> path = new List<string>();
    public List<string> pairs = new List<string>();

    private string s1;
    private string s2 = "";

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit)) return;

        string name = hit.collider.gameObject.name;
        string tag = hit.collider.gameObject.tag;

        if (s2 == name) return;

        string pair1 = s2 + name;
        string pair2 = name + s2;

        if (pairs.Contains(pair1) || pairs.Contains(pair2)) return;

        s1 = s2;
        s2 = name;

        path.Add(s2);

        if (string.IsNullOrEmpty(s1)) return;

        pairs.Add(pair1);

        GameEvents.current.NewLine(path);

        drawLine(s1, s2);

        /*if (tag == "end")
        {
            onEnd();
        }*/
    }

    private void drawLine(string s1, string s2)
    {
        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();

        go.name = "Line";
        go.tag = "line";

        lr.material = myMat;

        lr.material.color = new Color(1, 1, 1);

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        var gun = GameObject.Find(s1);
        var projectile = GameObject.Find(s2);

        lr.SetPosition(0, gun.transform.position);
        lr.SetPosition(1, projectile.transform.position);
    }

    private void onEnd()
    {
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
        // todo: validate order
        return true;
    }
}
