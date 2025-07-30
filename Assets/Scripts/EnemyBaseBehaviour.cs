using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseBehaviour : MonoBehaviour
{
    public GameObject player;

    public Vision vision;

    public Vector3 playerDistance;

    public EnemyStates currentState;

    public float angleToPlayer;

    public float moveSpeed;
    public float currentSpeed;
    public float maxSpeed;
    public int health;
    public int maxHealth;
    public int contactDamage;
    public float timerForResting;
    public float lengthWhenResting;

    public float lengthWhenPatrolling;

    public int movementFrequency;

    public bool onAlert;

    public float timeSinceAlert;

    public enum EnemyStates
    {
        attackingPlayer,
        followingPlayer,
        patrolling,
        resting,
    }

   
    
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == EnemyStates.attackingPlayer) { AttackingPlayer(); }
        else if (currentState == EnemyStates.followingPlayer) { ChasingPlayer(); }
        else if (currentState == EnemyStates.patrolling) { Patrolling(); }
        else if (currentState == EnemyStates.resting) { Resting(); }
        else { currentState = EnemyStates.resting; }

        timeSinceAlert += 1 * Time.deltaTime;
    }

    public void Resting()
    {
        if (onAlert)
        {
            currentState = EnemyStates.patrolling;
        }

        if (vision.targetObject != null)
        {
            currentState = EnemyStates.followingPlayer;
            onAlert = true;
        }

        timerForResting -= 1 * Time.deltaTime;

        if (timerForResting > 0)
        {
            currentSpeed += moveSpeed * Time.deltaTime;

            if (currentSpeed > maxSpeed * 0.5f)
            {
                currentSpeed = maxSpeed * 0.5f;
            }

            transform.Translate(currentSpeed * Time.deltaTime, 0, 0);
        }
        
        else if (Random.Range(1, movementFrequency) == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180, 180));
            timerForResting = lengthWhenResting;
        }


    }

    public void Patrolling()
    {
        if (!onAlert || timeSinceAlert == 30)
        {
            currentState = EnemyStates.resting;
            onAlert = false;
        }
    }

    public void ChasingPlayer()
    {
        playerDistance = player.transform.position - transform.position;
        angleToPlayer = Mathf.Atan2(playerDistance.y, playerDistance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleToPlayer));

        currentSpeed += moveSpeed * Time.deltaTime;

        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }

        transform.Translate(currentSpeed * Time.deltaTime, 0, 0);

        if (vision.targetObject == null)
        {
            currentState = EnemyStates.patrolling;
            timeSinceAlert = 0;
        }
    }

    public void AttackingPlayer()
    {
        if (vision.targetObject == null)
        {
            currentState = EnemyStates.patrolling;
            timeSinceAlert = 0;
        }
    }
}
