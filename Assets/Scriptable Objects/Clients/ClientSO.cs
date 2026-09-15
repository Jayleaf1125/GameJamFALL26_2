using UnityEngine;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;

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
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public DialougeSO Dialouge { get; private set; }
    public SerializedDictionary<Stats, int> EventStatDict;

    private void OnValidate()
    {
        if (Name.Length == 0) Debug.LogWarning($"{this.name} needs a name");

        if (EventStatDict.Count == 0) Debug.LogError("Event needs stats");

        foreach (KeyValuePair<Stats, int> pair in EventStatDict)
        {
            if (pair.Value < 0 || pair.Value > 3)
            {
                Debug.LogError($"{Name}'s {pair.Key} is out of range");
            }
        }

    }
}

/*
 - Create an EventManager that create events based on the stats
 
 */
