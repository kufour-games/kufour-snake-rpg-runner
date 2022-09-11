using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Sprite _dummyEnemySprite;
    [SerializeField] private int _maxEnemyCount = 3;
    [SerializeField] private float _checkDelaySeconds = 1;
    private int _currnetEnemyCount;
    private float _minSpawnProbability = 0;
    private float _maxSpawnProbability = 1;

    private Coroutine _checkDelay;

    private void Start()
    {
        _checkDelay = StartCoroutine(CheckDelay());
    }

    private IEnumerator CheckDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_checkDelaySeconds);
            if (CheckSpwan())
            {
                Spawn();
            }
        }
    }

    private bool CheckSpwan()
    {
        if(_currnetEnemyCount >= _maxEnemyCount)
        {
            return false;
        }

        var ratio = 1 - (float)_currnetEnemyCount / _maxEnemyCount;
        var spawnProbapility = Mathf.Lerp(_minSpawnProbability, _maxSpawnProbability, ratio);
        var currentProbability = Random01F;
        Debug.Log($"value {currentProbability} / prob {spawnProbapility}");
        return currentProbability <= spawnProbapility;
    }

    private void Spawn()
    {
        var monster = new GameObject("Monster");
        monster.transform.position = GetSpawnPosition();
        monster.AddComponent<SpriteRenderer>().sprite = _dummyEnemySprite;
        ++_currnetEnemyCount;
    }

    private Vector3 GetSpawnPosition()
    {
        var pos = Camera.main.ViewportToWorldPoint(new Vector3(Random01F, Random01F, 0));
        return new Vector3(pos.x, pos.y);
    }

    private float Random01F => Random.Range(0, 1f);
}
