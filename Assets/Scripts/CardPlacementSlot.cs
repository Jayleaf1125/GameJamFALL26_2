using UnityEngine;
using UnityEngine.EventSystems;

public class CardPlacementSlot : MonoBehaviour, IDropHandler
{
    VolunteerSO _selectedVolunteer;
    Card _selectedCard;

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
            //GetComponent<RectTransform>().transform.SetParent(eventData.pointerDrag.transform, false);
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            _selectedVolunteer = eventData.pointerDrag.GetComponent<Card>().Volunteer;
            eventData.pointerDrag.GetComponent<Card>().SetSlot(this);
            _selectedCard = eventData.pointerDrag.GetComponent<Card>();
        }
    }
    public void ClearVolunteer() => _selectedVolunteer = null;

    public void SubmitVolunteers()
    {
        if (_selectedVolunteer == null) return;
        JobManager.Instance.AddVolunteer(_selectedVolunteer);
        _selectedCard.transform.position = GameObject.Find("Card Generator").GetComponent<CardGenerator>().GetPlayerHandPos().position;
        //Debug.Log("Cards are loaded");
    }
}
