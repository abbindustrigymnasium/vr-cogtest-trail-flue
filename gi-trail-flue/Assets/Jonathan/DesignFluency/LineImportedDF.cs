using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineImportedDF : MonoBehaviour
{
  
    public Camera cam;
    public Material myMat;
    public string lineColorHEX;
    Color lineColor;

    public List<string> path = new List<string>();
    public List<string> pairs = new List<string>();


    private string s1;
    private string s2 = "";

    void Start()
    {
        ColorUtility.TryParseHtmlString(lineColorHEX, out lineColor);
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

        /*if (tag == "end")
        {
            onEnd();
        }*/
    }

    float mod(float x, float m) {
        float r = x % m;
        return r < 0 ? r + m : r;
    }

    private async void drawLine(string s1, string s2)
    {
        Vector3 start = GameObject.Find(s1).transform.position;
        Vector3 end = GameObject.Find(s2).transform.position;

        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();


        go.name = "Line";
        go.tag = "line";

        lr.material = myMat;
        lr.material.SetColor("_Color", lineColor);

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        lr.positionCount = 200;

        //Central angle between current start and end points
        float deltaSigma = Mathf.Acos(Vector3.Dot(start.normalized, end.normalized));

        //Angle between each point on the line
        float angleToNextPoint = deltaSigma / (lr.positionCount);

        //Sets start point so that the line is always drawn counterclockwise along the horizontal circle
        if (mod(Mathf.Atan2(end.z,end.x) - Mathf.Atan2(start.z,start.x), 2 * Mathf.PI) > Mathf.PI)
            {
                (start, end) = (end, start);
            }

        //Radial distance for start and end point
        float rhoStart = Mathf.Sqrt(Mathf.Pow(start.x,2f) + Mathf.Pow(start.y,2f) + Mathf.Pow(start.z,2f));
        float rhoEnd = Mathf.Sqrt(Mathf.Pow(end.x,2f) + Mathf.Pow(end.y,2f) + Mathf.Pow(end.z,2f));
        float totalPosition = (float)lr.positionCount;

        lr.SetPosition(0, start);
        lr.SetPosition((lr.positionCount - 1), end);
        for (int i = 1; i < (lr.positionCount - 1); i++) 
        {
            
            //Azimuthal angle for current start point
            float thetaStart = Mathf.Atan2(start.z,start.x);

            //Polar angle for current start point and end point
            float phiStart = Mathf.Atan2(Mathf.Sqrt(Mathf.Pow(start.x, 2f) + Mathf.Pow(start.z, 2f)), start.y);
            float phiEnd = Mathf.Atan2(Mathf.Sqrt(Mathf.Pow(end.x, 2f) + Mathf.Pow(end.z, 2f)),end.y);

            //Central angle between current start and end points
            float deltaSigmaNew = Mathf.Acos(Vector3.Dot(start.normalized, end.normalized));
            float newfloat = 12f;

            //Angle between north pole, start point and next point (atan2(y,x))
            float x_Start = Mathf.Cos(phiEnd) - Mathf.Cos(deltaSigmaNew)  * Mathf.Cos(phiStart);
            float y_Start = Mathf.Sqrt(Mathf.Max(0, Mathf.Pow(Mathf.Sin(deltaSigmaNew) * Mathf.Sin(phiStart), 2f) - Mathf.Pow(x_Start, 2f)));
            float triangularAngleStart = Mathf.Atan2(y_Start, x_Start);
            

            //Polar angle for new point 
            float phiNewPoint = Mathf.Acos(Mathf.Cos(angleToNextPoint) * Mathf.Cos(phiStart) + Mathf.Sin(angleToNextPoint) * Mathf.Sin(phiStart) * Mathf.Cos(triangularAngleStart));
            
            //Angle between start point, north pole and next point (atan2(y,x))
            float x_NewPoint = Mathf.Cos(angleToNextPoint) - Mathf.Cos(phiNewPoint)  * Mathf.Cos(phiStart);
            float y_NewPoint = Mathf.Sqrt(Mathf.Max(0, Mathf.Pow(Mathf.Sin(phiNewPoint) * Mathf.Sin(phiStart), 2f) - Mathf.Pow(x_NewPoint, 2f)));
            float poleAngleNew = Mathf.Atan2(y_NewPoint, x_NewPoint);

            //Azimuthal angle for next point
            float thetaNewPoint = thetaStart + poleAngleNew;

            //Radial distance for next point 
            float currentPosition = (float)i;
            float rhoNew = (((totalPosition - currentPosition)/totalPosition) * rhoStart + (currentPosition/totalPosition) * rhoEnd);
            

            Vector3 nextPoint = new Vector3(rhoNew * Mathf.Sin(phiNewPoint) * Mathf.Cos(thetaNewPoint), rhoNew * Mathf.Cos(phiNewPoint), rhoNew * Mathf.Sin(phiNewPoint) * Mathf.Sin(thetaNewPoint));
            
           
            lr.SetPosition(i, nextPoint);
            start = nextPoint;
        } 
    }


    private void OnEnd()
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
