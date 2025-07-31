using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float attackRate;
    public float attackTimer;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (attackTimer < 0)
        {
            attackTimer = attackRate;
            Shoot();
        }
        attackTimer -= 1 * Time.deltaTime;
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
