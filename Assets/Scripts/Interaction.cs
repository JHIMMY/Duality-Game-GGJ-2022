using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private DialogManager dialogManager;

    private GameObject currentObject;

    public static event Action OnDialogStarted; // the finished event is in the dialogManager

    public static event Action OnDrinkingElixir;
    public static event Action OnDrinkingAntidote;

    //private void OnCollisionEnter2D(Collision2D collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Elixir"))
        {
            currentObject = collision.gameObject;

            OnDialogStarted?.Invoke();
            var elixirTexts = new List<DialogData>();

            DialogData elixirSelection = new DialogData("/emote:Sad/Hey! I found an Elixir./wait:0.7/ Should I drink it?", "Big Head");
            elixirSelection.SelectList.Add("yes", "Yes");
            elixirSelection.SelectList.Add("no", "No");
            elixirSelection.Callback = () => DrinkElixirCheck();

            elixirTexts.Add(elixirSelection);
            dialogManager.Show(elixirTexts);
        }
        else if (collision.gameObject.CompareTag("Antidote"))
        {
            currentObject = collision.gameObject;

            OnDialogStarted?.Invoke();

            var antidoteTexts = new List<DialogData>();

            DialogData antidoteSelection = new DialogData("/emote:Happy/Ohh! I found an Antidote./wait:0.7/ Should I drink it?", "Big Head");
            antidoteSelection.SelectList.Add("yes", "Yes");
            antidoteSelection.SelectList.Add("no", "No");
            antidoteSelection.Callback = () => DrinkAntidoteCheck();

            antidoteTexts.Add(antidoteSelection);
            dialogManager.Show(antidoteTexts);
        }
        else if (collision.gameObject.CompareTag("ClueObject"))
        {
            currentObject = collision.gameObject;
            OnDialogStarted?.Invoke();


            var holder = currentObject.GetComponent<DialogHolder>();
            if (GameManager.GameTimeLine == Timeline.Present && holder.IsPresentExclusive ||
                GameManager.GameTimeLine == Timeline.Past && !holder.IsPresentExclusive)
            {
                var dialog = holder.DialogScript;
                dialog.ArrangeDialogList();
                dialogManager.Show(dialog.GetDialogDataList());
            }
            else
            {
                // show encrypted text
                List<DialogData> dialogDataList = new List<DialogData>();
                dialogDataList.Add(new DialogData("T%^kC(#@}jct9r;&(*$+k2lf=^,Ug~.]*tg7.>", "Big Head"));
                dialogDataList.Add(new DialogData("This Text is encrypted!!", "Big Head"));
                dialogManager.Show(dialogDataList);
            }            
        }
    }

    private void DrinkElixirCheck()
    {
        if (dialogManager.Result.Equals("yes"))
        {
            dialogManager.Show(new DialogData("All right!/wait:0.5//close/"));
            OnDrinkingElixir?.Invoke();
            Destroy(currentObject);
        }
        else if(dialogManager.Result.Equals("no"))
        {
            dialogManager.Show(new DialogData("Maybe later./wait:0.5//close/"));
        }

        // end object interaction -> now waits for the DialogManager.OnDialogFinished Event
       // OnObjectInteractFinished?.Invoke();
    }

    private void DrinkAntidoteCheck()
    {
        if (dialogManager.Result.Equals("yes"))
        {
            dialogManager.Show(new DialogData("All right!/wait:0.5//close/"));           
            OnDrinkingAntidote?.Invoke();
            Destroy(currentObject);
        }
        else if (dialogManager.Result.Equals("no"))
        {
            dialogManager.Show(new DialogData("Maybe later./wait:0.5//close/"));
        }

        // end object interaction
        //OnObjectInteractFinished?.Invoke();
    }
}
