
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGameManager : MonoBehaviour
{

    private float spawnDelay;

    [SerializeField]
    private EnemyObjectPool _objectPool;

    private int enemyCount = 0; 
    
    private void Update()
    {
        spawnDelay += Time.deltaTime;

        if (spawnDelay > 10)
        {
            var type = EnemyOffenceTypeExtensions.getRandomType();
            var enemyObject = _objectPool.MakeObj(type);
            enemyObject.transform.position = new Vector3(enemyCount, enemyCount);
            
            spawnDelay = 0;
            enemyCount++;
        }
    }
}