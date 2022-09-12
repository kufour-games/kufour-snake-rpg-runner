using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int offence; // 파워
    [SerializeField]
    private int offenceSpeed; // 연사
    [SerializeField]
    private int defence; // 방어력
    [SerializeField]
    private int health; // 체력

    [SerializeField]
    private int point;
    [SerializeField]
    private int score;
    [SerializeField]
    private EnemyOffenceType type;

    private float offenceDelay;
    
    public void Initialize(
        int offence,
        int offenceSpeed,
        int defence,
        int health,
        int point,
        int score,
        EnemyOffenceType type
    )
    {
        this.offence = offence;
        this.offenceSpeed = offenceSpeed;
        this.defence = defence;
        this.health = health;
        this.point = point;
        this.score = score;
        this.type = type;
    }

    private void Update()
    {
        offenceDelay += Time.deltaTime;

        if (offenceDelay > offenceSpeed)
        {
            Attack();
            offenceDelay = 0; // initialize
        }
    }

    private void Attack() // todo type 별로 공격에 대한 것 만들기
    {
        Debug.Log(type + " 공격");
    }

    // todo 죽었을 때 상호작용 interface ?
}