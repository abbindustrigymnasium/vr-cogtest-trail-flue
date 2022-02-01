using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{
    public GameObject spherePrefab;
    public Material lightMaterial;
    public Material darkMaterial;
    public Camera playerCamera;

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


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn(){
        for(var x = 0; x < ListOfSphereValues.GetLength(0); x ++){
            for(var y = 0; y < ListOfSphereValues.GetLength(1); y ++){
                spawnSphere(ListOfSphereValues[x,y].rho, ListOfSphereValues[x,y].theta, ListOfSphereValues[x,y].phi, ListOfSphereValues[x,y].color, ListOfSphereValues[x,y].label);  
                
            }
            do 
            {
                yield return null;
            } while (!Input.GetKeyDown("space"));

            GameObject[] spheres = GameObject.FindGameObjectsWithTag("sphere");

            for (int i=0; i < spheres.Length; i++){
                Destroy(spheres[i]);
            }
            GameObject[] lines = GameObject.FindGameObjectsWithTag("line");

            for (int i=0; i < lines.Length; i++){
                Destroy(lines[i]);
            }
            

        }
    }

    void spawnSphere(float rho, float theta, float phi, string color, string label){
        Vector3 spherePosition = new Vector3(rho * Mathf.Sin(phi) * Mathf.Cos(theta), rho * Mathf.Cos(phi), rho * Mathf.Sin(phi) * Mathf.Sin(theta));
        GameObject sphere = Instantiate(spherePrefab, spherePosition, Quaternion.identity) as GameObject;
        
        sphere.name = "Sphere" + rho + theta + phi;
        var sphereScript = sphere.GetComponent<TextOnObjectManager>();
        sphereScript.label = label;
        sphereScript.playerCamera = playerCamera;
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

}



