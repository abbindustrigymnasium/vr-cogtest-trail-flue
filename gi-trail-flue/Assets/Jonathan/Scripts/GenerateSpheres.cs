using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{
    public GameObject spherePrefab;
    public Camera playerCamera;
    public string lightColorHEX;
    public string darkColorHEX;
    Color LightColor;
    Color DarkColor;
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
            new SphereValues(15,0,90,"light","1"),
            new SphereValues(15,72,90,"dark","A"), 
            new SphereValues(15,144,90,"light","2"), 
            new SphereValues(15,216,90,"dark","B"), 
            new SphereValues(15,288,90,"light","3"), 
        },
        {
            new SphereValues(15,0,85,"dark","C"),
            new SphereValues(15,72,85,"light","4"), 
            new SphereValues(15,144,85,"dark","D"), 
            new SphereValues(15,216,85,"light","5"), 
            new SphereValues(15,288,85,"dark","E"), 
        },
        {
            new SphereValues(15,0,80,"light","6"),
            new SphereValues(15,72,80,"dark","F"), 
            new SphereValues(15,144,80,"light","7"), 
            new SphereValues(15,216,80,"dark","G"), 
            new SphereValues(15,288,80,"light","8"), 
        },
        {
            new SphereValues(15,0,75,"dark","H"),
            new SphereValues(15,72,75,"light","9"), 
            new SphereValues(15,144,75,"dark","I"), 
            new SphereValues(15,216,75,"light","10"), 
            new SphereValues(15,288,75,"dark","J"), 
        }
    };


    // Start is called before the first frame update
    void Start()
    {
        
        ColorUtility.TryParseHtmlString(lightColorHEX, out LightColor);
        ColorUtility.TryParseHtmlString(darkColorHEX, out DarkColor);
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


        var sphereRenderer = sphere.GetComponent<Renderer>();
        Color colorValue = color == "light" ? LightColor: DarkColor;
        sphereRenderer.material.SetColor("_Color", colorValue);
        sphere.SetActive(true);
    }

}



