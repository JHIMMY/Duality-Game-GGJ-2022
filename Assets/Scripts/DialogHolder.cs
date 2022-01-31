using Doublsb.Dialog;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    [SerializeField]
    private DialogMaker dialogScript;

    public DialogMaker DialogScript { 
        get 
        {
            return dialogScript;
        }
    }
}
