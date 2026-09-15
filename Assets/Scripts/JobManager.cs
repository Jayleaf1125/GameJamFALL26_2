using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class JobManager : Singleton<JobManager>
{
    [field: SerializeField] public List<VolunteerSO> SelectedVolunteers { get; private set; } = new List<VolunteerSO>();
    [field: SerializeField] public List<ClientSO> SelectedClients { get; private set; } = new List<ClientSO>();

    //public static event Action OnSelectedVolunteerSubmit = delegate { };
    bool _isSubmitted = false;

    private protected override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedVolunteers.Count > 0) _isSubmitted = true;

        if (_isSubmitted)
        {
            BeginAssignment();
            _isSubmitted = false;
        }
    }

    public void AddVolunteer(VolunteerSO volunteer)
    {
        SelectedVolunteers.Add(volunteer);
    }

    public void ClearVolunteers() => SelectedVolunteers.Clear();

    void BeginAssignment()
    {
        ClientSO currClient = SelectedClients[0];

        int totalNumOfStatsForEvent = 0;
        int volunteerProgressRate = 0;

        foreach (KeyValuePair<Stats, int> stats in currClient.EventStatDict)
        {
            totalNumOfStatsForEvent += stats.Value;
            //totalNumOfStatsForEvent += 1;

            switch (stats.Key)
            {
                case Stats.Sight:
                    int totalSight = 0;
                    foreach (VolunteerSO v in SelectedVolunteers) totalSight += v.Sight;
                    if (totalSight >= stats.Value) volunteerProgressRate += totalSight;
                    break;
                case Stats.Repair:
                    int totalReapir = 0;
                    foreach (VolunteerSO v in SelectedVolunteers) totalReapir += v.Repair;
                    if (totalReapir >= stats.Value) volunteerProgressRate += totalReapir;
                    break;
                case Stats.Speed:
                    int totalSpeed = 0;
                    foreach (VolunteerSO v in SelectedVolunteers) totalSpeed += v.Speed;
                    if (totalSpeed >= stats.Value) volunteerProgressRate += totalSpeed;
                    break;
                case Stats.Healing:
                    int totalHealing = 0;
                    foreach (VolunteerSO v in SelectedVolunteers) totalHealing += v.Healing;
                    if (totalHealing >= stats.Value) volunteerProgressRate += totalHealing;
                    break;
            }
        }

        Debug.Log($"Total Stats: {totalNumOfStatsForEvent}");
        Debug.Log($"Volunteer Progress: {volunteerProgressRate}");

        if (volunteerProgressRate >= totalNumOfStatsForEvent)
        {
            foreach (VolunteerSO v in SelectedVolunteers) v.IncreaseBurnout(1);
        }
        else
        {
            foreach (VolunteerSO v in SelectedVolunteers) v.IncreaseBurnout(2);
        }

        ClearVolunteers();

    }
}
