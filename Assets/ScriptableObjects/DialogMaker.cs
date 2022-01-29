using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

[CreateAssetMenu(menuName ="DialogMaker", fileName ="dialog1")]
public class DialogMaker : ScriptableObject
{
    [SerializeField]
    private string objectName;

    [SerializeField]
    private List<string> dialogList = new List<string>();

    List<DialogData> dialogDataList = new List<DialogData>();

    
    public void ArrangeDialogList()
    {
        foreach (var sentence in dialogList)
        {
            dialogDataList.Add(new DialogData(sentence, "Big Head")); // second parameter the character
        }
    }

    public List<DialogData> GetDialogDataList()
    {
        return dialogDataList;
    }
}
