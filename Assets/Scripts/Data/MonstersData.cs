using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Data", menuName = "Create Monster Data")]
public class MonstersData : ScriptableObject
{
[SerializeField]private string monsterName;
[SerializeField]private float maxhealth;
[SerializeField]private float damage;
[SerializeField]private float speed;

public string MonsterName { get{return monsterName;}}
public float MaxHealth { get{return maxhealth;}}
public float Damage { get{return damage;}}
public float Speed { get{return speed;}}
}
