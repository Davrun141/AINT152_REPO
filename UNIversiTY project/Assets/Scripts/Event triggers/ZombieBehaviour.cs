using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    public int health = 10;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + adjustExplosionAngle);
        Instantiate(explosionPrefab, transform.position, newRot);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(BulletHitData data)
    {
        health -= data.damage;
        Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + adjustExplosionAngle);
        Instantiate(explosionPrefab, data.hitLocation.position, newRot);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
