using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody controller;
    [SerializeField] float movementSpeed;
    
    private Vector3 moveAxis;

    private void Update()
    {
        controller.velocity = new Vector3(moveAxis.x, 0, moveAxis.z) * movementSpeed;
    }

    private void OnMove(InputValue value)
    {
        moveAxis.x = value.Get<Vector2>().x;
        moveAxis.z = value.Get<Vector2>().y;
    }
}
