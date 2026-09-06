using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Volunteer", menuName = "NPC/New Volunteer")]
public class VolunteerSO : ScriptableObject
{
    [SerializeField] string _name;
    [SerializeField] Image _portrait;
    [Header("Stats")]
    [Space(10)]
    [SerializeField, Range(0, 3)] int _sight;
    [SerializeField, Range(0, 3)] int _repair;
    [SerializeField, Range(0, 3)] int _speed;
    [SerializeField, Range(0, 3)] int _healing;
    [Space(10)]
    [SerializeField] float _burnout;
    //[SerializeField] Quirk
}
