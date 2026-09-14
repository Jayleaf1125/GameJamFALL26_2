using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] List<VolunteerSO> _listOfVolunteers;
    [SerializeField] GameObject _canvas;
    [SerializeField] GameObject _cardPrefab;
    [SerializeField] RectTransform _playerHand;

    float _prevCardPosX;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (VolunteerSO v in  _listOfVolunteers)
        {
            GameObject card = Instantiate(_cardPrefab, _playerHand);
            // Card Image
            card.transform.GetChild(1).GetComponent<Image>().sprite = v.Portrait;
            // Card Name
            card.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = v.Name;
            // Set Volunteer to card
            card.GetComponent<Card>().SetVolunteer(v);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_playerHand.position, 0.5f);
    }
}
