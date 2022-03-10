using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line2Imported : MonoBehaviour
{
    public Camera cam;
    public Material myMat;
    public int sphereTime = 0;

    public GameObject spherePrefab;
    public string lightColorHEX;
    public string darkColorHEX;
    Color LightColor;
    Color DarkColor;

        public List<SphereValues[,]> ActiveSphereList = new List<SphereValues[,]>
    {
        new SphereValues[,]
        {
            {
                new SphereValues(8,72,65,"white","1"),
                new SphereValues(8,120,75,"white","2"), 
                new SphereValues(8,210,70,"white","3"), 
                new SphereValues(8,164,95,"white","4"), 
                new SphereValues(8,280,70,"white","5"),
                new SphereValues(8,340,42,"white","6"), 
            },
            {
                new SphereValues(8,100,90,"white","1"),
                new SphereValues(8,72,55,"white","2"), 
                new SphereValues(8,248,75,"white","3"), 
                new SphereValues(8,216,95,"white","4"), 
                new SphereValues(8,2,70,"white","5"),
                new SphereValues(8,154,42,"white","6"), 
            },
            {
                new SphereValues(8,263,80,"white","1"),
                new SphereValues(8,156,60,"white","2"), 
                new SphereValues(8,6,63,"white","3"), 
                new SphereValues(8,200,115,"white","4"), 
                new SphereValues(8,45,55,"white","5"),
                new SphereValues(8,169,54,"white","6"), 
            },
            {
                new SphereValues(8,200,92,"white","1"),
                new SphereValues(8,15,69,"white","2"), 
                new SphereValues(8,80,95,"white","3"), 
                new SphereValues(8,281,85,"white","4"), 
                new SphereValues(8,165,87,"white","5"),
                new SphereValues(8,122,50,"white","6"), 
            },
            {
                new SphereValues(8,314,75,"white","1"),
                new SphereValues(8,106,85,"white","2"), 
                new SphereValues(8,194,73,"white","3"), 
                new SphereValues(8,297,78,"white","4"), 
                new SphereValues(8,126,88,"white","5"),
                new SphereValues(8,236,64,"white","6"), 
            },
            {
                new SphereValues(8,162,86,"white","1"),
                new SphereValues(8,106,71,"white","2"), 
                new SphereValues(8,203,74,"white","3"), 
                new SphereValues(8,50,90,"white","4"), 
                new SphereValues(8,293,120,"white","5"),
                new SphereValues(8,327,88,"white","6"), 
            },
            {
                new SphereValues(8,297,67,"white","1"),
                new SphereValues(8,157,100,"white","2"), 
                new SphereValues(8,27,89,"white","3"), 
                new SphereValues(8,243,112,"white","4"), 
                new SphereValues(8,128,45,"white","5"),
                new SphereValues(8,211,110,"white","6"), 
            },
            {
                new SphereValues(8,304,54,"white","1"),
                new SphereValues(8,60,71,"white","2"), 
                new SphereValues(8,335,92,"white","3"), 
                new SphereValues(8,97,96,"white","4"), 
                new SphereValues(8,173,86,"white","5"),
                new SphereValues(8,117,83,"white","6"), 
            },
            {
                new SphereValues(8,92,66,"white","1"),
                new SphereValues(8,248,97,"white","2"), 
                new SphereValues(8,83,53,"white","3"), 
                new SphereValues(8,121,81,"white","4"), 
                new SphereValues(8,200,77,"white","5"),
                new SphereValues(8,290,96,"white","6"), 
            },
            {
                new SphereValues(8,123,70,"white","1"),
                new SphereValues(8,110,66,"white","2"), 
                new SphereValues(8,357,79,"white","3"), 
                new SphereValues(8,315,50,"white","4"), 
                new SphereValues(8,224,104,"white","5"),
                new SphereValues(8,99,101,"white","6"), 
            },
            {
                new SphereValues(8,314,91,"white","1"),
                new SphereValues(8,221,87,"white","2"), 
                new SphereValues(8,113,87,"white","3"), 
                new SphereValues(8,337,110,"white","4"), 
                new SphereValues(8,190,120,"white","5"),
                new SphereValues(8,53,54,"white","6"), 
            },
            {
                new SphereValues(8,12,79,"white","1"),
                new SphereValues(8,76,68,"white","2"), 
                new SphereValues(8,296,114,"white","3"), 
                new SphereValues(8,188,67,"white","4"), 
                new SphereValues(8,335,99,"white","5"),
                new SphereValues(8,226,67,"white","6"), 
            },
            {
                new SphereValues(8,163,48,"white","1"),
                new SphereValues(8,74,57,"white","2"), 
                new SphereValues(8,114,68,"white","3"), 
                new SphereValues(8,247,100,"white","4"), 
                new SphereValues(8,307,108,"white","5"),
                new SphereValues(8,252,89,"white","6"), 
            },
            {
                new SphereValues(8,294,69,"white","1"),
                new SphereValues(8,203,55,"white","2"), 
                new SphereValues(8,125,47,"white","3"), 
                new SphereValues(8,10,91,"white","4"), 
                new SphereValues(8,352,60,"white","5"),
                new SphereValues(8,176,76,"white","6"), 
            },
            {
                new SphereValues(8,174,110,"white","1"),
                new SphereValues(8,49,69,"white","2"), 
                new SphereValues(8,267,106,"white","3"), 
                new SphereValues(8,335,98,"white","4"), 
                new SphereValues(8,90,95,"white","5"),
                new SphereValues(8,220,85,"white","6"), 
            },
            {
                new SphereValues(8,300,96,"white","1"),
                new SphereValues(8,253,83,"white","2"), 
                new SphereValues(8,185,63,"white","3"), 
                new SphereValues(8,133,70,"white","4"), 
                new SphereValues(8,93,58,"white","5"),
                new SphereValues(8,291,86,"white","6"), 
            },
            {
                new SphereValues(8,168,80,"white","1"),
                new SphereValues(8,38,84,"white","2"), 
                new SphereValues(8,244,52,"white","3"), 
                new SphereValues(8,280,117,"white","4"), 
                new SphereValues(8,76,56,"white","5"),
                new SphereValues(8,125,83,"white","6"), 
            },
            {
                new SphereValues(8,345,78,"white","1"),
                new SphereValues(8,256,99,"white","2"), 
                new SphereValues(8,12,79,"white","3"), 
                new SphereValues(8,137,52,"white","4"), 
                new SphereValues(8,180,87,"white","5"),
                new SphereValues(8,285,85,"white","6"), 
            },
            {
                new SphereValues(8,149,118,"white","1"),
                new SphereValues(8,203,79,"white","2"), 
                new SphereValues(8,9,71,"white","3"), 
                new SphereValues(8,327,92,"white","4"), 
                new SphereValues(8,256,118,"white","5"),
                new SphereValues(8,65,112,"white","6"), 
            },
            {
                new SphereValues(8,104,42,"white","1"),
                new SphereValues(8,284,64,"white","2"), 
                new SphereValues(8,122,104,"white","3"), 
                new SphereValues(8,177,118,"white","4"), 
                new SphereValues(8,244,70,"white","5"),
                new SphereValues(8,65,57,"white","6"), 
            },
        },
        new SphereValues[,]
        {
            {
                new SphereValues(8,72,65,"white","1"),
                new SphereValues(8,120,75,"black","2"), 
                new SphereValues(8,210,70,"white","3"), 
                new SphereValues(8,164,95,"black","4"), 
                new SphereValues(8,280,70,"white","5"),
                new SphereValues(8,340,42,"black","6"), 
            },
            {
                new SphereValues(8,100,90,"white","1"),
                new SphereValues(8,72,55,"black","2"), 
                new SphereValues(8,248,75,"white","3"), 
                new SphereValues(8,216,95,"black","4"), 
                new SphereValues(8,2,70,"white","5"),
                new SphereValues(8,154,42,"black","6"), 
            },
            {
                new SphereValues(8,263,80,"white","1"),
                new SphereValues(8,156,60,"black","2"), 
                new SphereValues(8,6,63,"white","3"), 
                new SphereValues(8,200,115,"black","4"), 
                new SphereValues(8,45,55,"white","5"),
                new SphereValues(8,169,54,"black","6"), 
            },
            {
                new SphereValues(8,200,92,"white","1"),
                new SphereValues(8,15,69,"black","2"), 
                new SphereValues(8,80,95,"white","3"), 
                new SphereValues(8,281,85,"black","4"), 
                new SphereValues(8,165,87,"white","5"),
                new SphereValues(8,122,50,"black","6"), 
            },
            {
                new SphereValues(8,314,75,"white","1"),
                new SphereValues(8,106,85,"black","2"), 
                new SphereValues(8,194,73,"white","3"), 
                new SphereValues(8,297,78,"black","4"), 
                new SphereValues(8,126,88,"white","5"),
                new SphereValues(8,236,64,"black","6"), 
            },
            {
                new SphereValues(8,162,86,"white","1"),
                new SphereValues(8,106,71,"black","2"), 
                new SphereValues(8,203,74,"white","3"), 
                new SphereValues(8,50,90,"black","4"), 
                new SphereValues(8,293,120,"white","5"),
                new SphereValues(8,327,88,"black","6"), 
            },
            {
                new SphereValues(8,297,67,"white","1"),
                new SphereValues(8,157,100,"black","2"), 
                new SphereValues(8,27,89,"white","3"), 
                new SphereValues(8,243,112,"black","4"), 
                new SphereValues(8,128,45,"white","5"),
                new SphereValues(8,211,110,"black","6"), 
            },
            {
                new SphereValues(8,304,54,"white","1"),
                new SphereValues(8,60,71,"black","2"), 
                new SphereValues(8,335,92,"white","3"), 
                new SphereValues(8,97,96,"black","4"), 
                new SphereValues(8,173,86,"white","5"),
                new SphereValues(8,117,83,"black","6"), 
            },
            {
                new SphereValues(8,92,66,"white","1"),
                new SphereValues(8,248,97,"black","2"), 
                new SphereValues(8,83,53,"white","3"), 
                new SphereValues(8,121,81,"black","4"), 
                new SphereValues(8,200,77,"white","5"),
                new SphereValues(8,290,96,"black","6"), 
            },
            {
                new SphereValues(8,123,70,"white","1"),
                new SphereValues(8,110,66,"black","2"), 
                new SphereValues(8,357,79,"white","3"), 
                new SphereValues(8,315,50,"black","4"), 
                new SphereValues(8,224,104,"white","5"),
                new SphereValues(8,99,101,"black","6"), 
            },
            {
                new SphereValues(8,314,91,"white","1"),
                new SphereValues(8,221,87,"black","2"), 
                new SphereValues(8,113,87,"white","3"), 
                new SphereValues(8,337,110,"black","4"), 
                new SphereValues(8,190,120,"white","5"),
                new SphereValues(8,53,54,"black","6"), 
            },
            {
                new SphereValues(8,12,79,"white","1"),
                new SphereValues(8,76,68,"black","2"), 
                new SphereValues(8,296,114,"white","3"), 
                new SphereValues(8,188,67,"black","4"), 
                new SphereValues(8,335,99,"white","5"),
                new SphereValues(8,226,67,"black","6"), 
            },
            {
                new SphereValues(8,163,48,"white","1"),
                new SphereValues(8,74,57,"black","2"), 
                new SphereValues(8,114,68,"white","3"), 
                new SphereValues(8,247,100,"black","4"), 
                new SphereValues(8,307,108,"white","5"),
                new SphereValues(8,252,89,"black","6"), 
            },
            {
                new SphereValues(8,294,69,"white","1"),
                new SphereValues(8,203,55,"black","2"), 
                new SphereValues(8,125,47,"white","3"), 
                new SphereValues(8,10,91,"black","4"), 
                new SphereValues(8,352,60,"white","5"),
                new SphereValues(8,176,76,"black","6"), 
            },
            {
                new SphereValues(8,174,110,"white","1"),
                new SphereValues(8,49,69,"black","2"), 
                new SphereValues(8,267,106,"white","3"), 
                new SphereValues(8,335,98,"black","4"), 
                new SphereValues(8,90,95,"white","5"),
                new SphereValues(8,220,85,"black","6"), 
            },
            {
                new SphereValues(8,300,96,"white","1"),
                new SphereValues(8,253,83,"black","2"), 
                new SphereValues(8,185,63,"white","3"), 
                new SphereValues(8,133,70,"black","4"), 
                new SphereValues(8,93,58,"white","5"),
                new SphereValues(8,291,86,"black","6"), 
            },
            {
                new SphereValues(8,168,80,"white","1"),
                new SphereValues(8,38,84,"black","2"), 
                new SphereValues(8,244,52,"white","3"), 
                new SphereValues(8,280,117,"black","4"), 
                new SphereValues(8,76,56,"white","5"),
                new SphereValues(8,125,83,"black","6"), 
            },
            {
                new SphereValues(8,345,78,"white","1"),
                new SphereValues(8,256,99,"black","2"), 
                new SphereValues(8,12,79,"white","3"), 
                new SphereValues(8,137,52,"black","4"), 
                new SphereValues(8,180,87,"white","5"),
                new SphereValues(8,285,85,"black","6"), 
            },
            {
                new SphereValues(8,149,118,"white","1"),
                new SphereValues(8,203,79,"black","2"), 
                new SphereValues(8,9,71,"white","3"), 
                new SphereValues(8,327,92,"black","4"), 
                new SphereValues(8,256,118,"white","5"),
                new SphereValues(8,65,112,"black","6"), 
            },
            {
                new SphereValues(8,104,42,"white","1"),
                new SphereValues(8,284,64,"black","2"), 
                new SphereValues(8,122,104,"white","3"), 
                new SphereValues(8,177,118,"black","4"), 
                new SphereValues(8,244,70,"white","5"),
                new SphereValues(8,65,57,"black","6"), 
            },
        },
        new SphereValues[,]
        {
            {
                new SphereValues(8,72,65,"white" ,"1"),
                new SphereValues(8,120,75,"white","A"), 
                new SphereValues(8,210,70,"white","2"), 
                new SphereValues(8,164,95,"white","B"), 
                new SphereValues(8,280,70,"white","3"),
                new SphereValues(8,340,42,"white","C"), 
            },
            {
                new SphereValues(8,100,90,"white","1"),
                new SphereValues(8,72,55,"white" ,"A"), 
                new SphereValues(8,248,75,"white","2"), 
                new SphereValues(8,216,95,"white","B"), 
                new SphereValues(8,2,70,"white"  ,"3"),
                new SphereValues(8,154,42,"white","C"), 
            },
            {
                new SphereValues(8,263,80,"white" ,"1"),
                new SphereValues(8,156,60,"white" ,"A"), 
                new SphereValues(8,6,63,"white"   ,"2"), 
                new SphereValues(8,200,115,"white","B"), 
                new SphereValues(8,45,55,"white"  ,"3"),
                new SphereValues(8,169,54,"white" ,"C"), 
            },
            {
                new SphereValues(8,200,92,"white","1"),
                new SphereValues(8,15,69,"white" ,"A"), 
                new SphereValues(8,80,95,"white" ,"2"), 
                new SphereValues(8,281,85,"white","B"), 
                new SphereValues(8,165,87,"white","3"),
                new SphereValues(8,122,50,"white","C"), 
            },
            {
                new SphereValues(8,314,75,"white","1"),
                new SphereValues(8,106,85,"white","A"), 
                new SphereValues(8,194,73,"white","2"), 
                new SphereValues(8,297,78,"white","B"), 
                new SphereValues(8,126,88,"white","3"),
                new SphereValues(8,236,64,"white","C"), 
            },
            {
                new SphereValues(8,162,86,"white" ,"1"),
                new SphereValues(8,106,71,"white" ,"A"), 
                new SphereValues(8,203,74,"white" ,"2"), 
                new SphereValues(8,50,90,"white"  ,"B"), 
                new SphereValues(8,293,120,"white","3"),
                new SphereValues(8,327,88,"white" ,"C"), 
            },
            {
                new SphereValues(8,297,67,"white" ,"1"),
                new SphereValues(8,157,100,"white","A"), 
                new SphereValues(8,27,89,"white"  ,"2"), 
                new SphereValues(8,243,112,"white","B"), 
                new SphereValues(8,128,45,"white" ,"3"),
                new SphereValues(8,211,110,"white","C"), 
            },
            {
                new SphereValues(8,304,54,"white","1"),
                new SphereValues(8,60,71,"white" ,"A"), 
                new SphereValues(8,335,92,"white","2"), 
                new SphereValues(8,97,96,"white" ,"B"), 
                new SphereValues(8,173,86,"white","3"),
                new SphereValues(8,117,83,"white","C"), 
            },
            {
                new SphereValues(8,92,66,"white" ,"1"),
                new SphereValues(8,248,97,"white","A"), 
                new SphereValues(8,83,53,"white" ,"2"), 
                new SphereValues(8,121,81,"white","B"), 
                new SphereValues(8,200,77,"white","3"),
                new SphereValues(8,290,96,"white","C"), 
            },
            {
                new SphereValues(8,123,70,"white" ,"1"),
                new SphereValues(8,110,66,"white" ,"A"), 
                new SphereValues(8,357,79,"white" ,"2"), 
                new SphereValues(8,315,50,"white" ,"B"), 
                new SphereValues(8,224,104,"white","3"),
                new SphereValues(8,99,101,"white" ,"C"), 
            },
            {
                new SphereValues(8,314,91,"white" ,"1"),
                new SphereValues(8,221,87,"white" ,"A"), 
                new SphereValues(8,113,87,"white" ,"2"), 
                new SphereValues(8,337,110,"white","B"), 
                new SphereValues(8,190,120,"white","3"),
                new SphereValues(8,53,54,"white"  ,"C"), 
            },
            {
                new SphereValues(8,12,79,"white"  ,"1"),
                new SphereValues(8,76,68,"white"  ,"A"), 
                new SphereValues(8,296,114,"white","2"), 
                new SphereValues(8,188,67,"white" ,"B"), 
                new SphereValues(8,335,99,"white" ,"3"),
                new SphereValues(8,226,67,"white" ,"C"), 
            },
            {
                new SphereValues(8,163,48,"white" ,"1"),
                new SphereValues(8,74,57,"white"  ,"A"), 
                new SphereValues(8,114,68,"white" ,"2"), 
                new SphereValues(8,247,100,"white","B"), 
                new SphereValues(8,307,108,"white","3"),
                new SphereValues(8,252,89,"white" ,"C"), 
            },
            {
                new SphereValues(8,294,69,"white","1"),
                new SphereValues(8,203,55,"white","A"), 
                new SphereValues(8,125,47,"white","2"), 
                new SphereValues(8,10,91,"white" ,"B"), 
                new SphereValues(8,352,60,"white","3"),
                new SphereValues(8,176,76,"white","C"), 
            },
            {
                new SphereValues(8,174,110,"white","1"),
                new SphereValues(8,49,69,"white"  ,"A"), 
                new SphereValues(8,267,106,"white","2"), 
                new SphereValues(8,335,98,"white" ,"B"), 
                new SphereValues(8,90,95,"white"  ,"3"),
                new SphereValues(8,220,85,"white" ,"C"), 
            },
            {
                new SphereValues(8,300,96,"white","1"),
                new SphereValues(8,253,83,"white","A"), 
                new SphereValues(8,185,63,"white","2"), 
                new SphereValues(8,133,70,"white","B"), 
                new SphereValues(8,93,58,"white" ,"3"),
                new SphereValues(8,291,86,"white","C"), 
            },
            {
                new SphereValues(8,168,80,"white" ,"1"),
                new SphereValues(8,38,84,"white"  ,"A"), 
                new SphereValues(8,244,52,"white" ,"2"), 
                new SphereValues(8,280,117,"white","B"), 
                new SphereValues(8,76,56,"white"  ,"3"),
                new SphereValues(8,125,83,"white" ,"C"), 
            },
            {
                new SphereValues(8,345,78,"white","1"),
                new SphereValues(8,256,99,"white","A"), 
                new SphereValues(8,12,79,"white" ,"2"), 
                new SphereValues(8,137,52,"white","B"), 
                new SphereValues(8,180,87,"white","3"),
                new SphereValues(8,285,85,"white","C"), 
            },
            {
                new SphereValues(8,149,118,"white","1"),
                new SphereValues(8,203,79,"white" ,"A"), 
                new SphereValues(8,9,71,"white"   ,"2"), 
                new SphereValues(8,327,92,"white" ,"B"), 
                new SphereValues(8,256,118,"white","3"),
                new SphereValues(8,65,112,"white" ,"C"), 
            },
            {
                new SphereValues(8,104,42,"white" ,"1"),
                new SphereValues(8,284,64,"white" ,"A"), 
                new SphereValues(8,122,104,"white","2"), 
                new SphereValues(8,177,118,"white","B"), 
                new SphereValues(8,244,70,"white" ,"3"),
                new SphereValues(8,65,57,"white"  ,"C"), 
            },
        },
    };

    private List<string> path = new List<string>();
    private List<string> pairs = new List<string>();

    private string s1;
    private string s2 = "";
    private bool cont = true;
    private bool done = false;

    void Start()
    {
        ColorUtility.TryParseHtmlString(lightColorHEX, out LightColor);
        ColorUtility.TryParseHtmlString(darkColorHEX, out DarkColor);
        StartCoroutine("Spawn");
        GameEvents2.current.onNewGame += OnNewGame;
        GameEvents2.current.onNewMode += OnNewMode;
    }

    void Update()
    {
        handleMouse();
    }

    float mod(float x, float m) {
        float r = x % m;
        return r < 0 ? r + m : r;
    }

    private void drawLine(string s1, string s2)
    {
        Vector3 start = GameObject.Find(s1).transform.position;
        Vector3 end = GameObject.Find(s2).transform.position;

        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();

        go.name = "Line";
        go.tag = "line";

        lr.material = myMat;
        lr.material.color = new Color(1,1,1);

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


    private void handleMouse()
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

        GameEvents2.current.NewLine(path, sphereTime);

        drawLine(s1, s2);
    }

    IEnumerator Spawn()
    {
        for(var x = 0; x < ActiveSphereList[sphereTime].GetLength(0); x ++){
            cont = true;
            for(var y = 0; y < ActiveSphereList[sphereTime].GetLength(1); y ++){
                spawnSphere(ActiveSphereList[sphereTime][x,y].rho, ActiveSphereList[sphereTime][x,y].theta, ActiveSphereList[sphereTime][x,y].phi, ActiveSphereList[sphereTime][x,y].color, ActiveSphereList[sphereTime][x,y].label, y == (ActiveSphereList[sphereTime].GetLength(1) - 1), y);  
                
            }
            do 
            {
                yield return null;
            } while (cont);

            noMoreSpheres();

        }
    }

    void spawnSphere(float rho, float theta, float phi, string color, string label, bool end, int y)
    {
        Vector3 spherePosition = new Vector3(rho * Mathf.Sin(phi) * Mathf.Cos(theta), rho * Mathf.Cos(phi), rho * Mathf.Sin(phi) * Mathf.Sin(theta));
        GameObject sphere = Instantiate(spherePrefab, spherePosition, Quaternion.identity) as GameObject;
        
        sphere.name = "Sphere" + y.ToString();
        if (end)
        {
            sphere.tag = "end";
        }
        var sphereScript = sphere.GetComponent<TextOnObject>();
        sphereScript.label = label;
        sphereScript.playerCamera = cam;

        var sphereRenderer = sphere.GetComponent<Renderer>();
        Color colorValue = color == "white" ? LightColor: DarkColor;
        sphereRenderer.material.SetColor("_Color", colorValue);

        sphere.SetActive(true);
    }

    public class SphereValues
    {
        public float rho; 
        public float theta; 
        public float phi; 
        public string color;
        public string label;

        public SphereValues(float rhoI, float thetaI, float phiI, string colorI, string labelI)
        {
            rho = rhoI;
            theta = thetaI * Mathf.Deg2Rad;
            phi =  phiI * Mathf.Deg2Rad;
            color = colorI;
            label = labelI;
        }

    }

    // SphereValues[,] ListOfSphereValuesDefault = new SphereValues[,]


    // SphereValues[,] ListOfSphereValuesColoreds = new SphereValues[,]

    void OnNewGame(List<string> path1, int sphereTime)
    {
        s1 = "";
        s2 = "";
        path = new List<string>();
        pairs = new List<string>();
        
        cont = false;

    }

    void OnNewMode()
    {
        s1 = "";
        s2 = "";
        path = new List<string>();
        pairs = new List<string>();
        
        cont = false;
        sphereTime += 1;
        noMoreSpheres();
        StartCoroutine("Spawn");
        if (sphereTime == 3)
        {
            done = true;
            Debug.Log("Game Done!");
            GameEvents2.current.GameDone();
        }
    }

    void noMoreSpheres()
    {
        GameObject[] spheres = GameObject.FindGameObjectsWithTag("sphere");

        for (int i=0; i < spheres.Length; i++){
            Destroy(spheres[i]);
        }
        GameObject[] lines = GameObject.FindGameObjectsWithTag("line");

        for (int i=0; i < lines.Length; i++){
            Destroy(lines[i]);
        }

        GameObject[] ends = GameObject.FindGameObjectsWithTag("end");

        for (int i=0; i < ends.Length; i++){
            Destroy(ends[i]);
        }
    }


    void OnDestroy()
    {
        GameEvents2.current.onNewGame -= OnNewGame;
        GameEvents2.current.onNewMode -= OnNewMode;
    }
}
