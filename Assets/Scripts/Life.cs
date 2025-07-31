using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float health;
    public int maxHealth;

    public GameObject drop;
    public float chance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Drop(chance, drop);
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Drop(float chance, GameObject drop)
    { 
        if (Random.Range(0, chance) <= 1)
        {
            Instantiate(drop, transform.position, transform.rotation);
        }
    }
}
