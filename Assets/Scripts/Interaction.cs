using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using System;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private DialogManager dialogManager;

    private GameObject currentObject;

    public static event Action OnObjectInteractStarted;
    public static event Action OnObjectInteractFinished;

    public static event Action OnDrinkingElixir;
    public static event Action OnDrinkingAntidote;

    private void OnEnable()
    {
        DialogManager.OnDialogFinished += DialogInteractionFiniched;
    }

    private void OnDisable()
    {
        DialogManager.OnDialogFinished -= DialogInteractionFiniched;
    }

    private void DialogInteractionFiniched()
    {
        OnObjectInteractFinished();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Elixir"))
        {
            OnObjectInteractStarted?.Invoke();
            currentObject = collision.gameObject;

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
            OnObjectInteractStarted?.Invoke();
            currentObject = collision.gameObject;

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
            OnObjectInteractStarted?.Invoke();
            currentObject = collision.gameObject;

            var dialog = currentObject.GetComponent<ObjectReader>().Dialog;
            dialogManager.Show(dialog);

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
