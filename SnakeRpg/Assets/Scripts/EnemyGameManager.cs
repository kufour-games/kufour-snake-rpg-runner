
using UnityEngine;

public class EnemyGameManager : MonoBehaviour
{

    private float _spawnDelay = 0;

    [SerializeField]
    private EnemyObjectPool objectPool;

    private int _enemyCount; 
    
    private void Update()
    {
        _spawnDelay += Time.deltaTime;

        if (_spawnDelay > 2)
        {
            EnemyOffenceType type = EnemyOffenceTypeExtensions.GetRandomType();
            GameObject enemyGameObject = objectPool.MakeEnemyObj(type);

            if (enemyGameObject is null) // == null 이라고하면 경고 나옴, https://tsyang.tistory.com/40 참고
            {
                Debug.LogWarning("the " + type + "Enemy is full");
                return;
            }

            Enemy enemy = enemyGameObject.GetComponent<Enemy>();

            if (enemy.getType() == EnemyOffenceType.REMOTE_AND_MULTI ||
                enemy.getType() == EnemyOffenceType.REMOTE_AND_SINGLE)
            {
                enemy.SetBullet(objectPool.MakeEnemyBulletObj(type));
            }
            
            enemy.transform.position = new Vector3(_enemyCount, _enemyCount);
            
            _spawnDelay = 0;
            _enemyCount++;
        }
    }
}