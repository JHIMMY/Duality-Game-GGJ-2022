using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Animator creditsPanelAnimator;

    private bool isCreditPanelIn;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCreditsPanel()
    {
        if (isCreditPanelIn)
        {
            creditsPanelAnimator.SetTrigger("CreditsOut");
            isCreditPanelIn = false;
        }
        else
        {
            creditsPanelAnimator.SetTrigger("CreditsIn");
            isCreditPanelIn = true;
        }
    }
}
