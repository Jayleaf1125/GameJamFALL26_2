using UnityEngine;
using AYellowpaper.SerializedCollections;

public enum Stats
{
    Sight,
    Repair, 
    Speed,
    Healing
};

[CreateAssetMenu(fileName = "New Client", menuName = "NPC/New Client")]
public class ClientSO : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] DialougeSO _dialouge;
    public SerializedDictionary<Stats, int> _eventStatDict; 

    private void OnValidate()
    {
        if (_eventStatDict.Count == 0) Debug.LogWarning("Event needs stats");

    }
}

/*
 - Create an EventManager that create events based on the stats
 
 */
