using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out Projectile projectile))
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
