using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContinousMovement : MonoBehaviour
{
    public float speed = 1;
    public InputActionProperty moveInputSource;
    public InputActionProperty turnInputSource;
    public Rigidbody rb;
    public float turnSpeed = 60;
    public Transform turnSource;

    public Transform directionSource;

    private Vector2 inputMoveAxis;
    private float inputTurnAxis;

    private void Update()
    {
        inputMoveAxis = moveInputSource.action.ReadValue<Vector2>();
        inputTurnAxis = turnInputSource.action.ReadValue<Vector2>().x;
    }

    private void FixedUpdate()
    {
        Quaternion yaw = Quaternion.Euler(0, directionSource.eulerAngles.y, 0);
        Vector3 direction = yaw * new Vector3(inputMoveAxis.x, 0, inputMoveAxis.y);

        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * speed);

        Vector3 axis = Vector3.up;
        float angle = turnSpeed * Time.fixedDeltaTime * inputTurnAxis;
        Quaternion q = Quaternion.AngleAxis(angle, axis);

        rb.MoveRotation(rb.rotation * q);
        Vector3 newPostion = q*(rb.position-turnSource.position) + turnSource.position;

        rb.MovePosition(newPostion);
    }
}
