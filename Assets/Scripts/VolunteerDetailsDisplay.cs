using TMPro;
using UnityEngine;

public class VolunteerDetailsDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _volunteerName;
    [SerializeField] TextMeshProUGUI _volunteerSightStat;
    [SerializeField] TextMeshProUGUI _volunteerRepairStat;
    [SerializeField] TextMeshProUGUI _volunteerHealingStat;
    [SerializeField] TextMeshProUGUI _volunteerSpeedStat;

    private void OnEnable()
    {
        Card.OnVolunteerCardClick += UpdateVolunteerDetailsDisplay;
    }

    private void OnDisable()
    {
        Card.OnVolunteerCardClick -= UpdateVolunteerDetailsDisplay;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolunteerDetailsDisplay(VolunteerSO volunteer)
    {
        _volunteerName.text = volunteer.Name;
        _volunteerSightStat.text = $"Sight: {volunteer.Sight}";
        _volunteerRepairStat.text = $"Repair: {volunteer.Repair}";
        _volunteerHealingStat.text = $"Healing: {volunteer.Healing}";
        _volunteerSpeedStat.text = $"Speed: {volunteer.Speed}";
    }
}
