using UnityEngine;

[CreateAssetMenu(fileName = "NewScene", menuName = "Scriptable Objects/Scene")]
public class SceneSO: ScriptableObject
{
    [Header("Scene information")]
    public string sceneName;
}