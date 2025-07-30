using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;

    public Transform playerTransform;
    public Transform gunTransform;

    public float attackSpeed;
    public float attackTimer;
    public float angleToMouse;

    public Vector3 mousePosition;
    public Vector3 mouseDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDistance = mousePosition - playerTransform.position;
        mouseDistance.z = 0;

        angleToMouse = Mathf.Atan2(mouseDistance.y, mouseDistance.x) * Mathf.Rad2Deg;

        gunTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angleToMouse - 90f));



        if (Input.GetKey(KeyCode.Space) && attackTimer > attackSpeed)
        {
            Shoot(bullet);
        }

        attackTimer += 1 * Time.deltaTime;
    }

    public void Shoot (GameObject  bullet)
    {
        Instantiate(bullet, playerTransform.position, gunTransform.rotation);
        attackTimer = 0;
    }
}
