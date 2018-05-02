using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public AudioClip shootypooty;
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public int health = 100;

    void Start()
    {
        SendHealthData();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(shootypooty);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        SendHealthData();
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
