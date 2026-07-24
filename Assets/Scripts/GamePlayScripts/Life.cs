using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float health;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void Die()
    {
        if (this.GetComponent<DropItems>() != null)
        {
            this.GetComponent<DropItems>().Drop(this.GetComponent<DropItems>().chance, this.GetComponent<DropItems>().drop);
        }
        Destroy(gameObject);    
    }

    
}
