using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool isRotate;

    private void Update()
    {
        if (isRotate)
            transform.Rotate(Vector3.back);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BorderBullet"))
        {
            gameObject.SetActive(false);
        }
    }
}
