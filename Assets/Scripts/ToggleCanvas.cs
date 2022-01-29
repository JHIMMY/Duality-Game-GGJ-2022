using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject exitCanvas;

    public void Toggle()
    {
        if (exitCanvas.activeSelf)
            exitCanvas.SetActive(false);
        else
            exitCanvas.SetActive(true);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
}
