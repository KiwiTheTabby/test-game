using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private GameObject attackObject;
    [SerializeField] private Transform objectTransform;
    [SerializeField] private InputAction attackAction;
    [SerializeField] private InputAction moveAction;


    public float attackSpeed;
    [SerializeField] private float attackTimer;
    
    [SerializeField] private Quaternion newRotation;

    public enum DirectionType
    {
        mouse,
        movement,
    }
    [SerializeField] private DirectionType directionType;

    public enum WeaponType
    {
        basicGun,
        machete,
    }
    [SerializeField] private WeaponType weaponType;

    // Start is called before the first frame update
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        moveAction = InputSystem.actions.FindAction("Move");

        directionType = DirectionType.movement;
    }

    // Update is called once per frame
    void Update()
    {

        if (directionType == DirectionType.mouse)
        {
            newRotation = MouseDirection(Camera.main.ScreenToWorldPoint(Input.mousePosition), objectTransform.position);
        }
        else if (directionType == DirectionType.movement)
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();
            if (moveValue != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveValue.y, moveValue.x) * Mathf.Rad2Deg;
                newRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
            }
        }

        if (attackAction.triggered && attackTimer > attackSpeed)
        {
            Attack(attackObject, newRotation, objectTransform);
            attackTimer = 0;
        }

        attackTimer += 1 * Time.deltaTime;
    }

    private void Attack (GameObject obj, Quaternion rotation, Transform transform)
    {
        Instantiate(obj, transform.position, rotation);
    }

    private Quaternion MouseDirection (Vector3 mousePos, Vector3 objectPos)
    {
        Vector3 direction = mousePos - objectPos;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle - 90f));
    }
}
