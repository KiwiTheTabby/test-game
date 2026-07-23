using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public Transform playerTransform;

    [SerializeField] private InputAction moveAction;
    [SerializeField] private Vector2 moveValue;

    public float moveSpeed;
    public float topSpeed;

    [SerializeField] private Vector2 velocity;
    [SerializeField] private float horizontalVelocity;
    [SerializeField] private float verticalVelocity;

    [SerializeField] private float baseVelocity;
    [SerializeField] private float friction;

    // Start is called before the first frame update
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();

        velocity += moveValue*moveSpeed;

        velocity *= friction;
        verticalVelocity *= friction;

        BoundValue(velocity.x, 1, topSpeed, 0);
        BoundValue(velocity.y, 1, topSpeed, 0);

        transform.Translate(velocity.x * Time.deltaTime, velocity.y * Time.deltaTime, 0);
    }

    private void BoundValue (float value, float floor, float maximum, float minimum)
    {
        if (Mathf.Abs(value) < floor) { value = minimum; }
        if ( value >= maximum ) { value = maximum; }
        if (value <= -maximum ) { value = -maximum; }
    }
}
