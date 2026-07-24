using UnityEngine;

public class DropItems : MonoBehaviour
{
    public GameObject drop;
    public float chance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Drop(float chance, GameObject drop)
    { 
        if (Random.Range(0, chance) <= 1)
        {
            Instantiate(drop, transform.position, transform.rotation);
        }
    }
}
