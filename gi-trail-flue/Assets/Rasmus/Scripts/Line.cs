using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Camera cam;
    public Material myMat;
    public Font font;

    public List<string> path = new List<string>();
    public List<string> pairs = new List<string>();

    private string s1 = "";
    private string s2 = "";

    void Start()
    {
        GameEvents.current.onNewGame += OnEnd;
    }

    void OnDestroy()
    {
        GameEvents.current.onNewGame -= OnEnd;
    }

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
        GameEvents.current.NewLine(path);

        if (string.IsNullOrEmpty(s1)) return;

        pairs.Add(pair1);

        drawLine(s1, s2);
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

    private void OnEnd(Level level)
    {
        // Destroy lines
        GameObject[] lines = GameObject.FindGameObjectsWithTag("line");

        foreach (GameObject line in lines)
        {
            Destroy(line);
        }

        // Reset variables
        s1 = "";
        s2 = "";

        // Clear lists
        path.Clear();
        pairs.Clear();

        // Destroy old spheres
        GameObject[] oldSpheres = GameObject.FindGameObjectsWithTag("sphere");

        foreach (GameObject sphere in oldSpheres)
        {
            Destroy(sphere);
        }

        // Create new spheres
        level.spawn(cam, font);
    }
}
