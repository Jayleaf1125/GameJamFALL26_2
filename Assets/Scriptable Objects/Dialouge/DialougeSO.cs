using UnityEngine;

[CreateAssetMenu(fileName = "New Dialouge Text", menuName = "Dialouge/New Dialouge Text")]
public class DialougeSO : ScriptableObject
{
    public ClientSO Client;
    [TextArea(5, 20)]
    public string dialougeText;
    public DialougeSO nextDialougeText;
}
