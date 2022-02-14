using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnObject : MonoBehaviour
{
    public Camera playerCamera;
    public string label;
    public Font font;

    void Awake()
    {
        LayerMask mask = LayerMask.NameToLayer("TEXT");

        // Rotate to face player
        transform.LookAt(playerCamera.transform);

        GameObject innerObject = new GameObject(name + "_original", typeof(MeshRenderer));
        innerObject.transform.SetParent(transform, false);

        MeshFilter innerObjectMeshFilter = innerObject.AddComponent<MeshFilter>();
        innerObjectMeshFilter.mesh = GetComponent<MeshFilter>().mesh;

        Renderer innerObjectRenderer = innerObject.GetComponent<Renderer>();
        innerObjectRenderer.material = GetComponent<Renderer>().material;

        name = name + "_textDecal";

        // Create render texture
        RenderTexture renderTexture = new RenderTexture(2048, 2048, 24);

        // Create material
        Material material = new Material(Shader.Find("Standard"));

        material.SetTexture("_MainTex", renderTexture);
        material.SetTextureOffset("_MainTex", new Vector2(-0.25f, 0f));

        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = 3000;

        // Exclude mask from player camera
        playerCamera.cullingMask &= ~(1 << mask);

        // Create camera
        GameObject cameraObj = new GameObject("Text Camera");
        cameraObj.transform.eulerAngles = new Vector3(0f, -180f, 0f);
        cameraObj.transform.SetParent(transform, false);

        Camera camera = cameraObj.AddComponent<Camera>();

        camera.backgroundColor = new Color(0, 0, 0, 0);
        camera.clearFlags = CameraClearFlags.Color;
        camera.cullingMask = 1 << mask;

        camera.targetTexture = renderTexture;
        camera.forceIntoRenderTexture = true;

        // Create canvas
        GameObject canvasObj = new GameObject("Canvas");
        canvasObj.transform.SetParent(cameraObj.transform, false);
        canvasObj.layer = mask;

        RectTransform canvasRectTransform = canvasObj.AddComponent<RectTransform>();
        canvasRectTransform.anchoredPosition3D = new Vector3(0, 0, 1);
        canvasRectTransform.sizeDelta = Vector2.one;

        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.transform.localScale = new Vector3(0.5f, 1f, 1f);
        
        canvasObj.AddComponent<CanvasScaler>();

        // Create text
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(canvasObj.transform, false);
        textObj.layer = mask;

        RectTransform textRectTransform = textObj.AddComponent<RectTransform>();
        textRectTransform.localScale = Vector3.one * 0.001f;
        textRectTransform.sizeDelta = new Vector2(2000, 1000);

        Text text = textObj.AddComponent<Text>();
        text.font = font;
        text.fontStyle = FontStyle.Bold;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.white;
        text.fontSize = 300;
        text.horizontalOverflow = HorizontalWrapMode.Wrap;
        text.verticalOverflow = VerticalWrapMode.Overflow;
        text.text = label;

        // Assign material
        GetComponent<MeshRenderer>().material = material;
    }
}
