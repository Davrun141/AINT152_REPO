using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public AudioClip shootypooty;
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public int health = 100;
    private Light spotlight;

    void Start()
    {
        SendHealthData();
        spotlight = gameObject.GetComponentInChildren<Light>(); //change to game object
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().PlayOneShot(shootypooty);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            VariableFlashlight();
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
        //add something here!..
    }



    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

    void VariableFlashlight()
    {
        spotlight.enabled = !spotlight.enabled;
    }
}
