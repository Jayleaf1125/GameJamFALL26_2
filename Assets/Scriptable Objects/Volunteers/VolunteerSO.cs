using UnityEngine;

[CreateAssetMenu(fileName = "New Volunteer", menuName = "NPC/New Volunteer")]
public class VolunteerSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Portrait { get; private set; }
    [Header("Stats")]
    [field: SerializeField, Range(0, 3)] public int Sight { get; private set; }
    [field: SerializeField, Range(0, 3)] public int Repair { get; private set; }
    [field: SerializeField, Range(0, 3)] public int Speed { get; private set; }
    [field: SerializeField, Range(0, 3)] public int Healing { get; private set; }
    [field: SerializeField, Range(0, 10)] public int Burnout { get; private set; }

    [field: SerializeField] public int CurrentBurnout { get; private set; } = 0;
    [field: SerializeField] public bool IsResting{ get; private set; } = true;

    public void ResetBurnout() => CurrentBurnout = 0;
    public void IncreaseBurnout(int num) => CurrentBurnout += num;
    public void DecreaseBurnout() => CurrentBurnout -= 2;
    public void SetIsResting(bool isResting) => IsResting = isResting;
}
