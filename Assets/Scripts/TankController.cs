using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private GameObject tankTower;
    [SerializeField] private GameObject tankBody;

    private float _speed = 3f;
    private float _velocity = 1f;
    
    private void Awake()
    {
        MoveJoystick.SendMovementDirection.AddListener(Movement);
        AttackJoystick.SendAttackDirection.AddListener(RotateTower);
    }

    public GameObject GetTower()
    {
        return tankTower;
    }

    private void RotateTower(Vector3 vec)
    {
        if (vec != Vector3.zero)
        {
            var target = Quaternion.LookRotation(new Vector3(vec.x, 0f, vec.y)).eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(tankTower.transform.eulerAngles.y
                , target, ref _velocity, .12f);
            
            //tankTower.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
            
            tankTower.transform.rotation = Quaternion.LookRotation(new Vector3(vec.x, 0, vec.y), Vector3.up);
        }
    }

    private void Movement(Vector3 vec)
    {
        if (vec != Vector3.zero)
        {
            var target = Quaternion.LookRotation(new Vector3(vec.x, 0f, vec.y)).eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(tankBody.transform.eulerAngles.y
                , target, ref _velocity, .12f);
            
            //tankBody.transform.rotation = Quaternion.Euler(0f, rotation, 0f);
            tankBody.transform.rotation = Quaternion.LookRotation(new Vector3(vec.x, 0, vec.y), Vector3.up);
            
            controller.Move(new Vector3(vec.x, 0, vec.y) * _speed * Time.deltaTime);
        }
    }
}
