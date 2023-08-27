using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New dialog array", menuName = "Scriptable Objects/Dialog")]
public class DialogArraySO : ScriptableObject
{
    public List<string> dialogs;
}   
