using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private int _damage;
    
    public bool isRotate;

    public void Initialize(int damage)
    {
        this._damage = damage;
    }

    public int getDamage()
    {
        return this._damage;
    }
    
    private void Update()
    {
        if (isRotate)
            transform.Rotate(Vector3.back);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
    }
}
