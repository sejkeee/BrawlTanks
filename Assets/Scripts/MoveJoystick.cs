using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoveJoystick : MonoBehaviour
{
    public static UnityEvent<Vector3> SendMovementDirection = new UnityEvent<Vector3>();

    [SerializeField] private Canvas interfaceCanvas;

    [SerializeField] private Image joystickIn;
    [SerializeField] private Image joystickOut;

    [SerializeField] private float _joystickRadius;
    
    private int _leftTouch = 95;
    private Vector2 _transPos;
    
    private void Start()
    {
        _joystickRadius = joystickOut.rectTransform.rect.height / 2 * interfaceCanvas.scaleFactor;
    }

    private void Update()
    {
        _transPos = new Vector2(transform.position.x, transform.position.y);
        
        var i = 0;
        while (i < Input.touchCount)
        {
            var t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                if ((t.position - _transPos).magnitude < _joystickRadius)
                {
                    _leftTouch = t.fingerId;
                    print(_leftTouch);

                    joystickIn.transform.position = t.position;
                }
            }
            else if (t.phase == TouchPhase.Moved && _leftTouch == t.fingerId)
            {
                Activate(t.position);
            }
            else if (t.phase == TouchPhase.Ended && _leftTouch == t.fingerId)
            {
                _leftTouch = 95;
                Deactivate();
            }

            ++i;
        }
        
        SendMovementDirection?.Invoke((joystickIn.transform.position - transform.position).normalized);
    }

    private void Activate(Vector2 pos)
    {
        if ((pos - _transPos).magnitude > _joystickRadius)
        {
            joystickIn.transform.position = _transPos+(pos-_transPos).normalized * _joystickRadius;
        }
        else
        {
            joystickIn.transform.position = pos;
        }
    }

    private void Deactivate()
    {
        joystickIn.transform.localPosition = Vector3.zero;
    }
}
    
