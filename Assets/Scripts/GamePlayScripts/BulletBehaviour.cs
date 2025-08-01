using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float bulletLife;
    public float damage;
    public float angleToTurn;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, angleToTurn, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        bulletLife -= 1 * Time.deltaTime;

        if (bulletLife < 0 )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        Life life = collision.GetComponent<Life>();

        if (life != null )
        {
            life.health -= damage;
        }

    }
}
