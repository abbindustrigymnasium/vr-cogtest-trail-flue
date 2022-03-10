using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionButton : MonoBehaviour
{
    public Button yourButton;
    public GameObject background;
    public Canvas canvas;
    public Text instText;
    public int instIndex = 0;
    public List<string> instructionTexts;

    void Start()
    {
        instructionTexts = new List<string>
            {"You will now see a few numbered spheres. Connect these spheres by clicking on them in order of their labels, 1-2-3-4-5-6",
            "Every other sphere will now be coloured blue. As in the previous test, connect the spheres by clicking on them in order of their labels, 1-2-3-4-5-6",
            "The spheres will now return to being in one colour. This time, every other label will be a letter. Connect the spheres by clicking on them in the order 1-A-2-B-3-C"};
        GameEvents2.current.onNewMode += OnNewMode;
        instText.text = instructionTexts[instIndex];
        Button btn = yourButton.GetComponent<Button>(); //Grabs the button component
	    btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameEvents2.current.InstructionDone();
    }

    void OnNewMode()
    {
        instIndex += 1;
        if (!(instIndex==3))
        {
            instText.text = instructionTexts[instIndex];
            background.SetActive(true);
            canvas.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnInstructionDone()
    // {

    // }

    void OnDestroy()
    {
        // GameEvents2.current.onInstructionDone -= OnInstructionDone;
        GameEvents2.current.onNewMode -= OnNewMode;
    }
}
