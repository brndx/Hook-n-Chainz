using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] private float Damage = 10.0f;
    [SerializeField] private Transform Projectile;
    [SerializeField] private float projectileSpeed = 100.0f;
    [SerializeField] private float projectileDuration = 2.0f;
    [SerializeField] private float lastFireTime = 0.0f;
    [SerializeField] private float fireWait = 0.1f;



    // Update is called once per frame
    void Update() {
        Fire();

    }

   
    void Fire() {
            if (Input.GetButton ("Fire1") && Time.time - lastFireTime > fireWait)
            {
                lastFireTime = Time.time;
                Shoot();
            } 
    }
    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Transform clone;
        clone = Instantiate(Projectile, new Vector3(transform.position.x, 15.0f, transform.position.z), Projectile.rotation);
        clone.GetComponent<Rigidbody>().velocity = new Vector3(((mousePosition - transform.position).normalized * projectileSpeed).x, 0, ((mousePosition - transform.position).normalized * projectileSpeed).z);
        Destroy(clone.gameObject, projectileDuration);
        RaycastHit hit;
        if (Physics.Raycast(mousePosition, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Enemy")
            Debug.Log(hit.collider.name);
        }
    }
}
