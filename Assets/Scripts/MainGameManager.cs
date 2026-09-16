using AYellowpaper.SerializedCollections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : Singleton<MainGameManager>
{
    [field: SerializeField] public int Round { get; private set; }
    [field: SerializeField] public SerializedDictionary<VolunteerSO, int> RestPeriodDict { get; private set; }

    public static event Action OnRoundEnd = delegate { };

    List<VolunteerSO> _listOfVolunteers;

    private protected override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _listOfVolunteers = GameObject.Find("Card Generator").GetComponent<CardGenerator>().ListOfVolunteers;

        foreach (VolunteerSO v in _listOfVolunteers)
        {
            RestPeriodDict.Add(v, 0);
        }

        Round = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndRound()
    {
        Round += 1;

        foreach (VolunteerSO v in _listOfVolunteers)
        {
            RestPeriodDict.Add(v, RestPeriodDict[v]+1);
        }

        OnRoundEnd?.Invoke();
    }
}
