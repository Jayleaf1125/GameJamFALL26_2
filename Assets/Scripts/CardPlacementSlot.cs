using UnityEngine;
using UnityEngine.EventSystems;

public class CardPlacementSlot : MonoBehaviour, IDropHandler
{
    VolunteerSO _selectedVolunteer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Dropped in slot");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            _selectedVolunteer = eventData.pointerDrag.GetComponent<Card>().Volunteer;
            eventData.pointerDrag.GetComponent<Card>().SetSlot(this);
        }
    }
    public void ClearVolunteer() => _selectedVolunteer = null;

    public void SubmitVolunteers()
    {
        if (_selectedVolunteer == null) return;
        JobManager.Instance.AddVolunteer(_selectedVolunteer);
        //Debug.Log("Cards are loaded");
    }
}
