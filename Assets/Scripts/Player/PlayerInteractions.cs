using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractions : MonoBehaviour
{
    DialogText dialogText;
    List<string> dialogs;
    [SerializeField] UnityEvent DialogStarted;
    [SerializeField] UnityEvent DialogFinished;

    private int dialogIndex = 0;

    void Start()
    {
        dialogText = DialogText.DialogTextInstance; 
    }
    void Update()
    {
        if(Input.GetButtonUp("Fire1"))
        {
            if(dialogs != null)
            {
                PerformDialog();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dialog"))
        {
           NPCDialog npcDialog = collision.GetComponent<NPCDialog>();
           if(npcDialog != null)
           {
            dialogs = npcDialog.ReturnLines();
           }
        }
    }

    private void OnTriggerExit2d(Collider2D collision)
    {
        if(collision.CompareTag("Dialog"))
        {
            dialogs = null;

        }
    }

    void PerformDialog()
    {
        if(dialogIndex == 0)
        {
            DialogStarted.Invoke();
        }
        if(dialogIndex >= dialogs.Count) {
            dialogText.FinishText();
            dialogIndex = 0;
            dialogs = null;
            DialogFinished.Invoke();
            return;
        }
        dialogText.DisplayText(dialogs[dialogIndex]);
        dialogIndex++;
    }
}
