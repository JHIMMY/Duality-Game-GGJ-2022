using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Animator creditsPanelAnimator;

    private bool isCreditPanelIn;
    private AudioSource au;
    private void Awake()
    {
        au = GetComponent<AudioSource>();
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

    public void ButtonHoverNoise()
    {
        au.PlayOneShot(au.clip);
    }
}
