using UnityEngine;

public interface IMonsterFactory
{
 GameObject CreateMonster(string monsterToSpawnName, Vector2 position);
}
