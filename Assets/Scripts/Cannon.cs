using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private GameObject _shotEffect;
    private void Awake()
    {
        AttackJoystick.SendAttack.AddListener(Shot);
    }

    private void Shot()
    {
        var projectile = Instantiate(_projectile, transform.position, transform.rotation);
        //var effect = Instantiate(_shotEffect, transform.position, transform.rotation);
    }
}
