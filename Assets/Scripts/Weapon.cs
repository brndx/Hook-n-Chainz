using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] private float fireRate = 0.0f;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private LayerMask notToHit;

   [SerializeField] private float timeToFire = 0.0f;
    private Transform firePoint;

	// Use this for initialization
	void Awake () {
        firePoint = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
