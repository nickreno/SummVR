using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmoothMoveTurn : MonoBehaviour
{
    public float speed = 1;
    public float turnSpeed = 1;
    public InputActionReference moveInput;
    public InputActionReference turnInput;
    private Rigidbody rb;
    private Vector2 inputMoveAxis;
    private float inputTurnAxis;

    private void Update()
    {
        inputMoveAxis = moveInput.action.ReadValue<Vector2>();
        inputTurnAxis = turnInput.action.ReadValue<Vector2>().x;
        transform.Translate(new Vector3 (inputMoveAxis.x, 0, inputMoveAxis.y) * Time.deltaTime * speed);
        transform.eulerAngles += (new Vector3(0, inputTurnAxis * turnSpeed, 0));
    }
}
