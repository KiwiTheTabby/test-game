using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBulletDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("detected");

        if (other.gameObject.CompareTag("Bullet"))
        {
            print("found");

            Destroy(other.gameObject);
        }
        else
        {
            print("null");
        }

        print(other.gameObject.tag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit");

        if (collision.gameObject.CompareTag("Bullet"))
        {
            print("shot");

            Destroy(collision.gameObject);
        }

        print(collision.gameObject.tag);
    }
}
