using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JobManager : Singleton<JobManager>
{
    [SerializeField] List<VolunteerSO> _selectedVolunteers;

    public static event Action OnSelectedVolunteerSubmit = delegate { };

    private protected override void Awake()
    {
        base.Awake();
        _selectedVolunteers = new List<VolunteerSO>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddVolunteer(VolunteerSO volunteer) => _selectedVolunteers.Add(volunteer);
}
