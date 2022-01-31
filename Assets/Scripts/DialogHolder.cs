using Doublsb.Dialog;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    [SerializeField]
    private DialogMaker dialogScript;

    [SerializeField]
    private bool isPresentExclusive;

    public bool IsPresentExclusive
    {
        get { return isPresentExclusive; }
    }

    public DialogMaker DialogScript { 
        get 
        {
            return dialogScript;
        }
    }
}
