using Doublsb.Dialog;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReader : MonoBehaviour
{
    [SerializeField]
    private DialogMaker objectDialogData;

    public List<DialogData> Dialog { get; private set; }
  
    void Start()
    {
        objectDialogData.ArrangeDialogList();
        Dialog = objectDialogData.GetDialogDataList();
    }
}
