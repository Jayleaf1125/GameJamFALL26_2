using UnityEngine;

[CreateAssetMenu(fileName = "New Volunteer", menuName = "NPC/New Volunteer")]
public class VolunteerSO : ScriptableObject
{
    [SerializeField] string _name;
    [Header("Stats")]
    [Space(10)]
    [SerializeField] int _sight;
    [SerializeField] int _repair;
    [SerializeField] int _speed;
    [SerializeField] int _damageControl;
    [Space(10)]
    [SerializeField] float _durability;
    //[SerializeField] Quirk
}
