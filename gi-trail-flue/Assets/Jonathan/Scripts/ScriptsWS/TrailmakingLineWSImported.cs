using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TrailmakingLineWSImported : MonoBehaviour
{

    public GameObject spherePrefab;
    public string lightColorHEX;
    public string darkColorHEX;
    Color LightColor;
    Color DarkColor;

    public Camera cam;
    public Material myMat;
    private List<string> path = new List<string>();
    private List<string> pairs = new List<string>();
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
    private string s1;
    private string s2 = "";
    private bool cont = true;
    // Start is called before the first frame update
    void Start()
    {
        ColorUtility.TryParseHtmlString(lightColorHEX, out LightColor);
        ColorUtility.TryParseHtmlString(darkColorHEX, out DarkColor);
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
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
            float rhoNew = (Mathf.Sqrt(Mathf.Pow(start.x,2f) + Mathf.Pow(start.y,2f) + Mathf.Pow(start.z,2f)) + Mathf.Sqrt(Mathf.Pow(end.x,2f) + Mathf.Pow(end.y,2f) + Mathf.Pow(end.z,2f)))/2;

            Vector3 nextPoint = new Vector3(rhoNew * Mathf.Sin(phiNewPoint) * Mathf.Cos(thetaNewPoint), rhoNew * Mathf.Cos(phiNewPoint), rhoNew * Mathf.Sin(phiNewPoint) * Mathf.Sin(thetaNewPoint));
            
           
            lr.SetPosition(i, nextPoint);
            start = nextPoint;
        } 

        
    }


    private void lineBezierCurve(Vector3 point0, Vector3 point1, Vector3 point2)
    {
        var go = new GameObject();
        var lr = go.AddComponent<LineRenderer>();

        go.name = "Line";
        go.tag = "line";

        lr.material = myMat;

        lr.material.color = new Color(1,1,1);

        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;

        lr.positionCount = 200;
        float t = 0f;
        Vector3 B = new Vector3(0, 0, 0);
        for (int i = 0; i < lr.positionCount; i++) 
        {
            B = (1 - t) * (1 - t) * point0 + 2 * (1 - t) * t * point1 + t * t * point2;
            lr.SetPosition(i, B);
            t += (1 / (float)lr.positionCount);
        }
    }

    private void onEnd()
    {
        validate();
        // Reset variables
        s1 = "";
        s2 = "";
        path = new List<string>();
        pairs = new List<string>();
        
        cont = false;
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

    private void handleMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                string name = hit.collider.gameObject.name;
                string tag = hit.collider.gameObject.tag;
                if (!(s2==name))
                {
                    string pair1 = s2 + name;
                    string pair2 = name + s2;
                    if (!(pairs.Contains(pair1)) && !(pairs.Contains(pair2)))
                    {
                        s1 = s2;
                        s2 = name;
                        path.Add(s2);
                        if (!string.IsNullOrEmpty(s1))
                        {
                            pairs.Add(pair1);
                            drawLine(s1, s2);
                            if (tag == "end.transform.position")
                            {
                                onEnd();
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator Spawn()
    {
        for(var x = 0; x < ListOfSphereValues.GetLength(0); x ++){
            cont = true;
            for(var y = 0; y < ListOfSphereValues.GetLength(1); y ++){
                spawnSphere(ListOfSphereValues[x,y].rho, ListOfSphereValues[x,y].theta, ListOfSphereValues[x,y].phi, ListOfSphereValues[x,y].color, ListOfSphereValues[x,y].label, y == (ListOfSphereValues.GetLength(1) - 1), y);  
                
            }
            do 
            {
                yield return null;
            } while (cont);

            GameObject[] spheres = GameObject.FindGameObjectsWithTag("sphere");

            for (int i=0; i < spheres.Length; i++){
                Destroy(spheres[i]);
            }
            GameObject[] lines = GameObject.FindGameObjectsWithTag("line");

            for (int i=0; i < lines.Length; i++){
                Destroy(lines[i]);
            }

            GameObject[] ends = GameObject.FindGameObjectsWithTag("end.transform.position");

            for (int i=0; i < ends.Length; i++){
                Destroy(ends[i]);
            }
            

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
    SphereValues[,] ListOfSphereValues = new SphereValues[,]
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

        // {
        //     new SphereValues(15,0,90,"white","1"),
        //     new SphereValues(15,72,90,"black","A"), 
        //     new SphereValues(15,144,90,"white","2"), 
        //     new SphereValues(15,216,90,"black","B"), 
        //     new SphereValues(15,288,90,"white","3"), 
        // },
        // {
        //     new SphereValues(15,0,85,"black","C"),
        //     new SphereValues(15,72,85,"white","4"), 
        //     new SphereValues(15,144,85,"black","D"), 
        //     new SphereValues(15,216,85,"white","5"), 
        //     new SphereValues(15,288,85,"black","E"), 
        // },
        // {
        //     new SphereValues(15,0,80,"white","6"),
        //     new SphereValues(15,72,80,"black","F"), 
        //     new SphereValues(15,144,80,"white","7"), 
        //     new SphereValues(15,216,80,"black","G"), 
        //     new SphereValues(15,288,80,"white","8"), 
        // },
        // {
        //     new SphereValues(15,0,75,"black","H"),
        //     new SphereValues(15,72,75,"white","9"), 
        //     new SphereValues(15,144,75,"black","I"), 
        //     new SphereValues(15,216,75,"white","10"), 
        //     new SphereValues(15,288,75,"black","J"), 
        // }
    };

}
