using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLaser : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        AttackJoystick.SendAttackDirection.AddListener(Rotate);
    }

    private void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider) _lineRenderer.SetPosition(1, hit.point);
        }
    }
    
    private void Rotate(Vector3 vec)
    {
        _lineRenderer.enabled = vec != Vector3.zero;
    }
}
