using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DynamicJoystick _joystick;

    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        if (!controller) {
            controller = GetComponent<PlayerController>();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            if (_rigidbody.velocity.magnitude > 0.1f) {
                controller.Move();
            }
        }
        else {
            controller.StopMove();
        }
    }

    
}
