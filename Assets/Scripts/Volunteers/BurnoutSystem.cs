using System;
using UnityEngine;

public class BurnoutSystem : MonoBehaviour
{
    VolunteerSO _volunteer;

    int _currBurnout;
    int _maxBurnout;

    public static event Action OnRetire = delegate { };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _volunteer = GetComponent<Card>().Volunteer;
        _currBurnout = 0;
        _maxBurnout = _volunteer.Burnout;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseBurnout()
    {
        _currBurnout += 1;
    }
    public void DecreaseBurnout()
    {
        _currBurnout -= 1;
    }
}
