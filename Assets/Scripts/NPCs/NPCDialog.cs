using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] private DialogArraySO dialogArraySO;

    public List<string> ReturnLines()
    {
        return dialogArraySO.dialogs;
    }
}
