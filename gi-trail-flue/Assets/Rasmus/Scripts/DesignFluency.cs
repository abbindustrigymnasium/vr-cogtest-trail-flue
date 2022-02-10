using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignFluency : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onClick += OnClick;
    }

    void OnClick()
    {
        Debug.Log("Click");
    }

    void OnDestroy()
    {
        GameEvents.current.onClick -= OnClick;
    }
}
