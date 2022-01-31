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
        dialogDataList.Clear();
        foreach (var sentence in dialogList)
        {
            dialogDataList.Add(new DialogData(sentence, "Big Head")); // second parameter the character
        }
    }


    public List<DialogData> GetDialogDataList()
    {
        return dialogDataList;
    }

    public List<DialogData> GetEncryptedDataList()
    {
        dialogDataList.Add(new DialogData("T%^kC(#@}jct9r;&(*$+k2lf=^,Ug~.]*tg7.>", "Big Head"));
        dialogDataList.Add(new DialogData("This Text is encrypted!!", "Big Head"));
        return dialogDataList;
    }
}
