using UnityEngine;

public class HealthCollectable : Collectable
{
    public float heal;

    public override void OnCollect(GameObject collector)
    {
        Life life = collector.GetComponent<Life>();

        if (life != null)
        {
            life.health += heal;
        }

        Destroy(gameObject);
    }

}
