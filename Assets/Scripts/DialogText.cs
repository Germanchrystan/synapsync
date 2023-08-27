using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogText : MonoBehaviour
{
    private static TextMeshProUGUI text;
    private static Image image;
    static private DialogText instance;
    static public DialogText DialogTextInstance { get { return instance; }}

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>(true);
        image = GetComponentInChildren<Image>(true);
    }
    
    public void DisplayText(string dialog)
    {
        text.text = dialog;
        SetDialogActive(true);
    }

    public void FinishText()
    {
        SetDialogActive(false);
    }

    private void SetDialogActive(bool active) 
    {
        image.gameObject.SetActive(active);
        text.gameObject.SetActive(active);
    }

}
