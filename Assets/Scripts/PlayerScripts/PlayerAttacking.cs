using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] private GameObject attackObject;
    [SerializeField] private Transform objectTransform;
    [SerializeField] private InputAction attackAction;


    public float attackSpeed;
    [SerializeField] private float attackTimer;
    
    [SerializeField] private Quaternion newRotation;

    public enum DirectionType
    {
        mouse,
        movement,
    }
    [SerializeField] private DirectionType directionType;

    // Start is called before the first frame update
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
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
        
        }

        if (attackAction.triggered && attackTimer > attackSpeed)
        {
            Attack(attackObject);
        }

        attackTimer += 1 * Time.deltaTime;
    }

    private void Attack (GameObject obj)
    {
        Instantiate(obj, objectTransform.position, newRotation);
        attackTimer = 0;
    }

    private Quaternion MouseDirection (Vector3 mousePos, Vector3 objectPos)
    {
        Vector3 direction = mousePos - objectPos;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle - 90f));
    }
}
