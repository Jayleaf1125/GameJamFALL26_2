using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Use this to just keep track of the stats (I think)
public class Card : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public VolunteerSO Volunteer { get; private set; }

    public static event Action<VolunteerSO> OnVolunteerCardClick = delegate { };

    RectTransform _rectTransform;
    CanvasGroup _canvasGroup;

    CardPlacementSlot _slot;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolunteer(VolunteerSO volunteer) => Volunteer = volunteer;
    public void SetSlot(CardPlacementSlot slot) => _slot = slot;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnVolunteerCardClick.Invoke(Volunteer);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_slot != null) _slot.ClearVolunteer();

        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.6f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        const float FULLY_VISIBLE = 1f;

        _canvasGroup.alpha = FULLY_VISIBLE;
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += (eventData.delta / GameObject.Find("Test Gameplay Canvas").GetComponent<Canvas>().scaleFactor);
    }
}
