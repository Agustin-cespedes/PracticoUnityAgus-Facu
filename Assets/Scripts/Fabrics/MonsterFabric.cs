using System;
using UnityEngine;

public class MonsterFabric : MonoBehaviour, IMonsterFactory
{
    [Serializable]
    private struct MonstersData
    {
        public string monsterName;
        public GameObject monsterPrefab;
    }

    [SerializeField] private MonstersData[] monsterDataBase;
    
    
    public GameObject CreateMonster(string monsterToSpawnName, Vector2 position)
    {
        foreach (var data in monsterDataBase)
        {
            if (data.monsterName == monsterToSpawnName)
                return Instantiate(data.monsterPrefab, position, Quaternion.identity);
        }

        return null;
    }
}
