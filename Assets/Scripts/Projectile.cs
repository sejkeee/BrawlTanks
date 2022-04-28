using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public GameObject effect;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var effectInstance = Instantiate(effect, transform.position, transform.rotation);

        if (other.GetComponent<Enemy>() != null)
        {
            print("IS ENEMY");
            Destroy(other.gameObject);
        }
        
        Destroy(gameObject);
    }
}
