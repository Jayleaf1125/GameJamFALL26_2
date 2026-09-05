using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    [Header("Dialouge System")]
    [SerializeField] DialougeSO _currrentDialouge;
    [SerializeField] TextMeshProUGUI _dialougeText;
    [SerializeField] TextMeshProUGUI _dialougeName;
    [SerializeField] TextMeshProUGUI _btnText;
    [SerializeField] Image _dialougeImage;

    bool _isDialougeEnabled = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dialougeText.text = _currrentDialouge.dialougeText;
        _dialougeName.text = _currrentDialouge.dialougeName;
        //dialougeImage.sprite = currrentDialouge.dialougeImage ?? null;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currrentDialouge.nextDialougeText == null)
        {
            _btnText.text = "End Dialouge";
            _isDialougeEnabled = false;
        }

        if (!_isDialougeEnabled) gameObject.SetActive(false);
    }

    public void NextText()
    {
        if (_currrentDialouge.nextDialougeText != null)
        {
            _currrentDialouge = _currrentDialouge.nextDialougeText;
            _dialougeText.text = _currrentDialouge.dialougeText;
            _dialougeName.text = _currrentDialouge.dialougeName;
            //dialougeImage.sprite = currrentDialouge.dialougeImage;
        }
    }
}
