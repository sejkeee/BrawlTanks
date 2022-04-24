using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main_Menu
{
    public class RotateTank : MonoBehaviour
    {
        [SerializeField] private Transform _tank;

        private void Update()
        {
            if(Input.GetMouseButton(0))
                _tank.localEulerAngles -= new Vector3(0, Input.GetAxis("Mouse X"), 0);
        }
    }
}

