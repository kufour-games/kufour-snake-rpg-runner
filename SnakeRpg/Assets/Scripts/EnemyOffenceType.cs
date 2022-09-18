using UnityEngine;

public enum EnemyOffenceType
{
    SHORT_AND_SINGLE,
    SHORT_AND_MULTI,
    REMOTE_AND_SINGLE,
    REMOTE_AND_MULTI
}

public static class EnemyOffenceTypeExtensions
{
    public static EnemyOffenceType GetRandomType()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                return EnemyOffenceType.SHORT_AND_SINGLE;

            case 1:
                return EnemyOffenceType.SHORT_AND_MULTI;

            case 2:
                return EnemyOffenceType.REMOTE_AND_SINGLE;

            case 3:
                return EnemyOffenceType.REMOTE_AND_MULTI;
        }

        return EnemyOffenceType.SHORT_AND_SINGLE;
    }
}