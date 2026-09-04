using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
// Fix the import to be AYellowPaper



public enum Stats
{
    Sight,
    Repair, 
    Speed,
    DamageControl
};

[CreateAssetMenu(fileName = "New Client", menuName = "NPC/New Client")]
public class ClientSO : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] DialougeSO _dialouge;
    public SerializedDictionary<Stats, int> _eventStatDict; // 


    private void OnValidate()
    {
        if (_eventStatDict.Count == 0) Debug.LogError("Event needs stats");

    }
}

/*
 - Create an EventManager that create events based on the stats
 
 */
