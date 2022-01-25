using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public Camera cam;
    public Material myMat;
    private List<string> path = new List<string>();
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
                // Debug.Log(name);
                s1 = s2;
                s2 = name;
                path.Add(s2);
                Debug.Log(path);
                if (!string.IsNullOrEmpty(s1) && !(s1==s2))
                {
                    SomeFunction(s1, s2);
                }
            }
        }
    }

    private void SomeFunction(string s1, string s2)
    {
        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();

        lr.material = myMat;

        lr.material.color = new Color(1,1,1);

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
 
        var gun = GameObject.Find(s1);
        var projectile = GameObject.Find(s2);
 
        lr.SetPosition(0, gun.transform.position);
        lr.SetPosition(1, projectile.transform.position);
    }
}
