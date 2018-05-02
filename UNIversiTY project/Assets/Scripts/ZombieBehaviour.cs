﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

    public int health = 10;
    public int damage = 2;
    public GameObject explosionPrefab;
    public float adjustExplosionAngle = 0.0f;

    private Transform player;

    void Start()
    {
        if (GameObject.FindWithTag("Player"))
        {
            player = GameObject.FindWithTag("Player").transform;
            GetComponent<MoveTowardsObject>().target = player;
            GetComponent<SmoothLookAtTarget2D>().target = player;
        }
        //Physics2D.IgnoreLayerCollision(8, 9);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SendMessage("TakeDamage", damage);
        }
    }


    //public void TakeDamage(int damage)
    //{
    //    health -= damage;
    //    Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + adjustExplosionAngle);
    //    Instantiate(explosionPrefab, transform.position, newRot);

    //    if (health <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public void TakeDamage(BulletHitData data)
    {
        health -= data.damage;
        Quaternion newRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + adjustExplosionAngle);
        Instantiate(explosionPrefab, data.hitLocation.position, newRot);

        if (health <= 0)
        {
            GetComponent<AddScore>().DoSendScore();

            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }
}
