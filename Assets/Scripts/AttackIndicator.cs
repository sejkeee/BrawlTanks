using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackIndicator : MonoBehaviour
{
    [SerializeField] private Image indicator;

    
    private void Awake()
    {
        AttackJoystick.SendAttackDirection.AddListener(Rotate);
    }

    private void Rotate(Vector3 vec)
    {
        indicator.gameObject.SetActive(vec != Vector3.zero);
    }
}
