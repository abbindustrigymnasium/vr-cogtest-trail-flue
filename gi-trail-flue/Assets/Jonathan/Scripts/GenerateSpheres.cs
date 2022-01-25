using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{
    public GameObject spherePrefab;


    private float[,,] toGenerate = {{{10,1,1,1},{20,1,1,0},{30,1,1,1},{40,1,1,0},{50,1,1,1},{60,1,1,0}},
                                    {{10,1,2,1},{20,1,2,0},{30,1,2,1},{40,1,2,0},{50,1,2,1},{60,1,2,0}},
                                    {{10,2,1,1},{20,2,1,0},{30,2,1,1},{40,2,1,0},{50,2,1,1},{60,2,1,0}},
                                    {{10,2,2,1},{20,2,2,0},{30,2,2,1},{40,2,2,0},{50,2,2,1},{60,2,2,0}},
                                    {{10,1,0,1},{20,1,0,0},{30,1,0,1},{40,1,0,0},{50,1,0,1},{60,1,0,0}}
    };
    // Start is called before the first frame update
    void Start()
    {
        // GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // sphere.transform.position = new Vector3(0,0.5f,0);
        // spawnSphere(5, 60, 30, 0);
        StartCoroutine("Spawn");
    }

    // Update is called once per 
    IEnumerator Spawn(){
        for(var x = 0; x < toGenerate.GetLength(0); x ++){
            for(var y = 0; y < toGenerate.GetLength(1); y ++){
                spawnSphere(toGenerate[x,y,0], toGenerate[x,y,1], toGenerate[x,y,2], (int)toGenerate[x,y,3]);
                
            }
            yield return new WaitForSeconds(1.0f);
            GameObject[] objects = GameObject.FindGameObjectsWithTag("sphere");

            for (int i=0; i<objects.Length; i++){
                Destroy(objects[i]);
            }

        }
    }
    // void Update()
    // {
        

    //     if (Input.GetKeyDown("space"))
    //     {
    //         GameObject[] objects = GameObject.FindGameObjectsWithTag("sphere");

    //         for (int i=0; i<objects.Length; i++){
    //             Destroy(objects[i]);
    //         }
    //         for (int i=0; i<Random.Range(6, 15); i++){
    //             spawnSphere(Random.Range(10f, 30f), Random.Range(0f,Mathf.PI * 3 /2), Random.Range(0f,Mathf.PI/2), Random.Range(0,2));
    //         }
            

    //     }
    // }

    public void spawnSphere(float rho, float theta, float phi, int colored = 1){
        Vector3 spherePosition = new Vector3(rho * Mathf.Sin(phi) * Mathf.Cos(theta), rho * Mathf.Cos(phi), rho * Mathf.Sin(phi) * Mathf.Sin(theta));
        GameObject sphere = Instantiate(spherePrefab, spherePosition, Quaternion.identity) as GameObject;
        sphere.transform.LookAt(Vector3.zero);
        var cubeRenderer = sphere.GetComponent<Renderer>();

        if (colored == 1)
        {
            cubeRenderer.material.SetColor("_Color", Color.black);
        }
         if (colored == 0)
        {
            cubeRenderer.material.SetColor("_Color", Color.white);
        }
    }
}



