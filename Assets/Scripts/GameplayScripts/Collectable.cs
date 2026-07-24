using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollect(collision.gameObject);
    }

    public virtual void OnCollect(GameObject collector)
    {
        
    }

}

