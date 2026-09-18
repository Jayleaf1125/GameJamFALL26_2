using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : Singleton<DialougeManager>
{
    [Header("Dialouge System")]
    [SerializeField] DialougeSO _currrentDialouge;
    [SerializeField] TextMeshProUGUI _dialougeText;
    [SerializeField] TextMeshProUGUI _dialougeName;
    [SerializeField] TextMeshProUGUI _btnText;
    [SerializeField] Image _dialougeImage;

    [SerializeField] GameObject _dialougePrefab;
    [SerializeField] GameObject _mainAreaPrefab;

    bool _isDialougeEnabled = true;

    private protected override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currrentDialouge = JobManager.Instance.SelectedClients[0].Dialouge;
        _dialougeText.text = _currrentDialouge.dialougeText;
        _dialougeName.text = _currrentDialouge.Client.Name;
        _dialougeImage.sprite = _currrentDialouge.Client.Portrait;
        _btnText.text = "Next";
        SetMainAreaPrefabActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currrentDialouge != null && _currrentDialouge.nextDialougeText == null)
        {
            _btnText.text = "End Dialouge";
            //_isDialougeEnabled = false;
            //StartCoroutine(Patience());
            //SetDialougePrefabActive(false);
            //SetMainAreaPrefabActive(true);
        }

        if (_currrentDialouge == null)
        {
            SetDialougePrefabActive(false);
            SetMainAreaPrefabActive(true);
            _currrentDialouge = null;
            _btnText.text = "Next";
        }



        //if (!_isDialougeEnabled)
        //{
        //    _isDialougeEnabled = true;
        //}
    }

    IEnumerator Patience()
    {
        yield return new WaitForSeconds(10f);
    }

    public void NextText()
    {
        if (_currrentDialouge.nextDialougeText != null)
        {
            _currrentDialouge = _currrentDialouge.nextDialougeText;
            _dialougeText.text = _currrentDialouge.dialougeText;
            _dialougeName.text = _currrentDialouge.Client.Name;
            _dialougeImage.sprite = _currrentDialouge.Client.Portrait;
        } else { 
            _currrentDialouge = null;
        }
    }

    public void SetDialougePrefabActive(bool active) => _dialougePrefab.SetActive(active);
    public void SetMainAreaPrefabActive(bool active) => _mainAreaPrefab.SetActive(active);
    public void SetNewDialouge(DialougeSO dialouge) => _currrentDialouge = dialouge;
}
