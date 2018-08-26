using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] private float fireRate = 0.0f;
    [SerializeField] private float Damage = 10.0f;
    [SerializeField] private LayerMask WhatToHit;

    [SerializeField] private float timeToFire = 0.0f;
    private Transform firePoint;

    // Use this for initialization
    void Awake() {
        InitializeFirePoint();
    }

    // Update is called once per frame
    void Update() {
        Fire();

    }

    void InitializeFirePoint() {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint!");
        }
    }
    void Fire() {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1")) {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton ("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }    
    }
    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, WhatToHit);
        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100, Color.clear);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.green);
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
        }
    }
}
