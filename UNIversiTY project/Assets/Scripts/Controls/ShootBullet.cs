using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawnRight;
    public Transform bulletSpawnLeft;
    public float fireTime = 0.5f;
    private bool isFiring = false;
    private string lastFireFrom = "Left";

    void SetFiring()
    {
        isFiring = false;
    }

    void Fire()
    {
        isFiring = true;
        if (lastFireFrom == "Left")
        {
            lastFireFrom = "Right";
            Instantiate(bulletPrefab, bulletSpawnRight.position, bulletSpawnRight.rotation);
        } else
        {
            lastFireFrom = "Left";
            Instantiate(bulletPrefab, bulletSpawnLeft.position, bulletSpawnLeft.rotation);
        }

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}
