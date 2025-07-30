using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float bulletLife;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
