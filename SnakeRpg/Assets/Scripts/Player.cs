using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float health;

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    /**
     * - 충돌은 3가지의 케이스, 그리고 2가지 타입을 가진다.
     * 1. 케이스
     *   1. 적 충돌
     *   2. 원가리 공격 충돌
     *   3. 근거리 공격 충돌
     * 2. 타입
     *   1. 단일
     *   2. 연쇄
     */
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("EnemySward"))
        {
            Vector3 dirVec = transform.position - col.gameObject.transform.position;
            
            Rigidbody2D rigid = GetComponent<Rigidbody2D>();

            transform.position = (dirVec.normalized * 3) - transform.position;
            
            
        } else if (col.gameObject.CompareTag("EnemyBullet"))
        {
            var bullet = col.gameObject.GetComponent<EnemyBullet>();
            health -= bullet.getDamage();
        } 
        
        // if (col.gameObject.CompareTag("EnemyBullet") || col.gameObject.CompareTag("Enemy"))
        // {
        //     // todo 동시에 맞으면 체력이 2 깍일 수 있으므로 예외 처리 필요
        //     //      boolean 으로 flag 처리로 막음
        //     // flag -> get set
        //     //  compareSet 1
        //
        //     life--;
        //     gameManager.UpdateLifeIcon(life);
        //
        //     if (life == 0)
        //     {
        //         gameManager.GameOver();
        //     }
        //     else
        //     {
        //         gameManager.RespawnPlayer();
        //     }
        //
        //     gameObject.SetActive(false); // 다시 살리는건 다른 Object에게 시켜야함, 스스로 할 수 없는 일
        //     // onEvent thread에서 처리되는게 아니라 signal만 주고 다른 thread에서 처리한다? -> UI thread 에서 처리
        // }
        //
        // if (col.gameObject.CompareTag("Item"))
        // {
        //     // Item component = col.gameObject.GetComponent<Item>();
        //     // switch (component.type)
        //     // {
        //     //     case ItemType.Coin:
        //     //         score += 1000;
        //     //         break;
        //     //     case ItemType.Boom:
        //     //         boomEffect.SetActive(true);
        //     //         Invoke("OffBoomEffect", 4f);
        //     //
        //     //         foreach (var o in objectManager.GetPool(ObjectType.EnemyL))
        //     //         {
        //     //             checkAndHit(o);
        //     //         }
        //     //         foreach (var o in objectManager.GetPool(ObjectType.EnemyM))
        //     //         {
        //     //             checkAndHit(o);
        //     //         }
        //     //         foreach (var o in objectManager.GetPool(ObjectType.EnemyS))
        //     //         {
        //     //             checkAndHit(o);
        //     //         }
        //     //         
        //     //         foreach (var o in objectManager.GetPool(ObjectType.bulletEnemyA))
        //     //         {
        //     //             checkAndDelete(o);
        //     //         }
        //     //
        //     //         foreach (var o in objectManager.GetPool(ObjectType.bulletEnemyB))
        //     //         {
        //     //             checkAndDelete(o);
        //     //         }
        //     //         
        //     //         break;
        //     //     case ItemType.Power:
        //     //         if (maxPower == power)
        //     //         {
        //     //             score += 500;
        //     //         }
        //     //         else
        //     //         {
        //     //             power++;
        //     //             AddFollower();
        //     //         }
        //     //         break;
        //     // }
        //     // col.gameObject.SetActive(false);
        // }
    }
}