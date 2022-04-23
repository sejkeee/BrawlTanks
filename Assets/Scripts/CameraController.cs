using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _cameraMain;
    
    [SerializeField] private TankController _tank;
    [SerializeField] private Transform _followingPoint;
    
    private Vector3 _target;
    private float _speed = 5f;
    private bool _isAttacking;

    private void Awake()
    {
        AttackJoystick.SendAttackDirection.AddListener(IsAttacking);
    }

    private void Start()
    {
        _cameraMain = GetComponentInChildren<Camera>();
    }
    
    
    private void Update()
    {
        _target = _isAttacking ? _followingPoint.transform.position : _tank.transform.position;
        
        transform.Translate((_target - transform.position) * _speed * Time.deltaTime);
    }

    private void IsAttacking(Vector3 vec)
    {
        _isAttacking = !(vec == Vector3.zero);
    }
    
}
