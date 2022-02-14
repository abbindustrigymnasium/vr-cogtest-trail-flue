using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line2 : MonoBehaviour
{
    public Camera cam;
    public Material myMat;

    public GameObject spherePrefab;
    public string lightColorHEX;
    public string darkColorHEX;
    Color LightColor;
    Color DarkColor;

    private List<string> path = new List<string>();
    private List<string> pairs = new List<string>();

    private string s1;
    private string s2 = "";
    private bool cont = true;

    void Start()
    {
        ColorUtility.TryParseHtmlString(lightColorHEX, out LightColor);
        ColorUtility.TryParseHtmlString(darkColorHEX, out DarkColor);
        StartCoroutine("Spawn");
        GameEvents2.current.onNewGame += OnNewGame;
    }

    void Update()
    {
        handleMouse();
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

        GameEvents2.current.NewLine(path);

        drawLine(s1, s2);
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

            GameObject[] ends = GameObject.FindGameObjectsWithTag("end");

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
    };

    void OnNewGame(List<string> path1)
    {
        s1 = "";
        s2 = "";
        path = new List<string>();
        pairs = new List<string>();
        
        cont = false;
    }


    void OnDestroy()
    {
        GameEvents2.current.onNewGame -= OnNewGame;
    }
}
