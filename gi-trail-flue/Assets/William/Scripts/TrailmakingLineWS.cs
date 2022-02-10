using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailmakingLineWS : MonoBehaviour
{

    public GameObject spherePrefab;
    public Material lightMaterial;
    public Material darkMaterial;

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
        "Sphere4_textDecal"
    };
    private int corrects = 0;
    private int wrongs = 0;
    private string s1;
    private string s2 = "";
    private bool cont = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
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
        // GameObject[] lines = GameObject.FindGameObjectsWithTag("line");
        // foreach (GameObject line in lines)
        // {
        //     Destroy(line);
        // }
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
        var sphereScript = sphere.GetComponent<TextOnObjectManager>();
        sphereScript.label = label;
        sphereScript.playerCamera = cam;
        // var sphereRenderer = sphere.GetComponent<Renderer>();

        // if (color == "black")
        // {
        //     sphereRenderer.material = darkMaterial;
        // }
        //  if (color == "white")
        // {
        //     sphereRenderer.material = lightMaterial;
        // }
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
            new SphereValues(15,0,90,"white","1"),
            new SphereValues(15,72,90,"black","A"), 
            new SphereValues(15,144,90,"white","2"), 
            new SphereValues(15,216,90,"black","B"), 
            new SphereValues(15,288,90,"white","3"), 
        },
        {
            new SphereValues(15,0,85,"black","C"),
            new SphereValues(15,72,85,"white","4"), 
            new SphereValues(15,144,85,"black","D"), 
            new SphereValues(15,216,85,"white","5"), 
            new SphereValues(15,288,85,"black","E"), 
        },
        {
            new SphereValues(15,0,80,"white","6"),
            new SphereValues(15,72,80,"black","F"), 
            new SphereValues(15,144,80,"white","7"), 
            new SphereValues(15,216,80,"black","G"), 
            new SphereValues(15,288,80,"white","8"), 
        },
        {
            new SphereValues(15,0,75,"black","H"),
            new SphereValues(15,72,75,"white","9"), 
            new SphereValues(15,144,75,"black","I"), 
            new SphereValues(15,216,75,"white","10"), 
            new SphereValues(15,288,75,"black","J"), 
        }
    };

}
