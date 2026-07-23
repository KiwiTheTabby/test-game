using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;

    [SerializeField] private Transform objectTransform;

    public float attackSpeed;
    [SerializeField] private float attackTimer;
    private float angleToMouse;

    private Vector3 mousePosition;
    private Vector3 mouseDistance;

    private Quaternion newRotation;

    [SerializeField] private InputAction attackAction;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = attackAction.ReadValue<bool>();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDistance = mousePosition - objectTransform.position;
        mouseDistance.z = 0;

        angleToMouse = Mathf.Atan2(mouseDistance.y, mouseDistance.x) * Mathf.Rad2Deg;

        newRotation = Quaternion.Euler(new Vector3(0, 0, angleToMouse - 90f));



        if (isAttacking && attackTimer > attackSpeed)
        {
            Shoot(bullet);
        }

        attackTimer += 1 * Time.deltaTime;
    }

    private void Shoot (GameObject  bullet)
    {
        Instantiate(bullet, objectTransform.position, newRotation);
        attackTimer = 0;
    }
}
