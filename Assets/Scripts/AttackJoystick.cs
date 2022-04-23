using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AttackJoystick : MonoBehaviour
{
    public static UnityEvent<Vector3> SendAttackDirection = new UnityEvent<Vector3>();
    public static UnityEvent SendAttack = new UnityEvent();

    [SerializeField] private Canvas interfaceCanvas;

    [SerializeField] private Image joystickIn;
    [SerializeField] private Image joystickOut;
    
    [SerializeField] private float _joystickRadius;

    private int _rightTouch = 99;
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
                    _rightTouch = t.fingerId;
                    print(_rightTouch);
                    joystickIn.transform.position = t.position;
                }
            }
            else if (t.phase == TouchPhase.Moved && _rightTouch == t.fingerId)
            {
                Activate(t.position);
            }
            else if (t.phase == TouchPhase.Ended && _rightTouch == t.fingerId)
            {
                _rightTouch = 99;
                Deactivate();
            }

            ++i;
        }
        
        SendAttackDirection?.Invoke((joystickIn.transform.position - transform.position).normalized);
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
        SendAttack?.Invoke();
        joystickIn.transform.position = transform.position;
    }
}