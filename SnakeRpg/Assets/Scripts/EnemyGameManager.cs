
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

        if (spawnDelay > 2)
        {
            var type = EnemyOffenceTypeExtensions.getRandomType();
            Enemy enemyObject = _objectPool.MakeEnemyObj(type).GetComponent<Enemy>();
            
            if (enemyObject.getType() == EnemyOffenceType.REMOTE_AND_MULTI ||
                enemyObject.getType() == EnemyOffenceType.REMOTE_AND_SINGLE)
            {
                enemyObject.SetBullet(_objectPool.MakeEnemyBulletObj(type));
            }
            
            enemyObject.transform.position = new Vector3(enemyCount, enemyCount);
            
            spawnDelay = 0;
            enemyCount++;
        }
    }
}