using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public GameObject enemyBasePrefab;

    private GameObject[] _enemyShortAndSingles;

    private GameObject[] _enemyShortAndMulties;

    private GameObject[] _enemyRemoteAndSingles;

    private GameObject[] _enemyRemoteAndMulties;

    private GameObject[] _targetPool;

    private void Awake()
    {
        _enemyShortAndSingles = new GameObject[5];
        _enemyShortAndMulties = new GameObject[5];
        _enemyRemoteAndSingles = new GameObject[5];
        _enemyRemoteAndMulties = new GameObject[5];
        Generate();
    }

    void Generate()
    {
        for (int index = 0; index < _enemyShortAndSingles.Length; index++)
        {
            _enemyShortAndSingles[index] = Instantiate(enemyBasePrefab);
            _enemyShortAndSingles[index].SetActive(false);
            EnemyInitialize(_enemyShortAndSingles, index, EnemyOffenceType.SHORT_AND_SINGLE);
        }

        for (int index = 0; index < _enemyShortAndMulties.Length; index++)
        {
            _enemyShortAndMulties[index] = Instantiate(enemyBasePrefab);
            _enemyShortAndMulties[index].SetActive(false);
            EnemyInitialize(_enemyShortAndMulties, index, EnemyOffenceType.SHORT_AND_MULTI);
        }

        for (int index = 0; index < _enemyRemoteAndSingles.Length; index++)
        {
            _enemyRemoteAndSingles[index] = Instantiate(enemyBasePrefab);
            _enemyRemoteAndSingles[index].SetActive(false);
            EnemyInitialize(_enemyRemoteAndSingles, index, EnemyOffenceType.REMOTE_AND_SINGLE);
        }

        for (int index = 0; index < _enemyRemoteAndMulties.Length; index++)
        {
            _enemyRemoteAndMulties[index] = Instantiate(enemyBasePrefab);
            _enemyRemoteAndMulties[index].SetActive(false);
            EnemyInitialize(_enemyRemoteAndMulties, index, EnemyOffenceType.REMOTE_AND_MULTI);
        }
    }

    private void EnemyInitialize(GameObject[] gameObjects, int index, EnemyOffenceType type)
    {
        Enemy enemy = gameObjects[index].GetComponent<Enemy>();

        enemy.Initialize(
            offence: 10, // todo 각 값들도 DTO로 전달
            offenceSpeed: 10,
            defence: 10,
            health: 10,
            point: 10,
            score: 10,
            type: type
        );
    }

    public GameObject MakeObj(EnemyOffenceType type)
    {
        switch (type)
        {
            case EnemyOffenceType.SHORT_AND_SINGLE:
                _targetPool = _enemyShortAndSingles;
                break;
            case EnemyOffenceType.SHORT_AND_MULTI:
                _targetPool = _enemyShortAndMulties;
                break;
            case EnemyOffenceType.REMOTE_AND_SINGLE:
                _targetPool = _enemyRemoteAndSingles;
                break;
            case EnemyOffenceType.REMOTE_AND_MULTI:
                _targetPool = _enemyRemoteAndMulties;
                break;
        }

        foreach (var targetObject in _targetPool)
        {
            if (!targetObject.activeSelf) // 비 활성화 되어있다면 반환하라
            {
                targetObject.SetActive(true);
                return targetObject;
            }
        }

        return null;
    }

    public GameObject[] GetPool(EnemyOffenceType type)
    {
        switch (type)
        {
            case EnemyOffenceType.SHORT_AND_SINGLE:
                _targetPool = _enemyShortAndSingles;
                break;
            case EnemyOffenceType.SHORT_AND_MULTI:
                _targetPool = _enemyShortAndMulties;
                break;
            case EnemyOffenceType.REMOTE_AND_SINGLE:
                _targetPool = _enemyRemoteAndSingles;
                break;
            case EnemyOffenceType.REMOTE_AND_MULTI:
                _targetPool = _enemyRemoteAndMulties;
                break;
        }

        return _targetPool;
    }
}