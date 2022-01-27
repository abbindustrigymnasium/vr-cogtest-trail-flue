using UnityEngine;
using System.Collections;
 
public class CamImported : MonoBehaviour
{
    // horizontal rotation speed
    public float horizontalSpeed = 0.3f;
    // vertical rotation speed
    public float verticalSpeed = 0.3f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public Camera cam;
 
    void Start()
    {
        
    }
 
    void Update()
    {
        float mouseX = (Input.GetKey("right") ? 1 : 0) * horizontalSpeed - (Input.GetKey("left") ? 1 : 0) * horizontalSpeed;
        float mouseY = (Input.GetKey("up") ? 1 : 0) * verticalSpeed - (Input.GetKey("down") ? 1 : 0) * verticalSpeed;
 
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
 
        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
    }
}