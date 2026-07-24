using UnityEngine;
using UnityEngine.Events;

public class PlayerLife : Life
{

    //TODO: Make the player death event work!!!!!! it doesn't rn
    public UnityEvent onPlayerDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        
        if (this.gameObject.CompareTag("Player"))
        {
            HealthBarUIHandler.instance.SetHealthBar(health, maxHealth);
        }
    }

    public override void Die()
    {
        Collider2D collider = this.GetComponent<Collider2D>();
        collider.enabled = false;

        health = 0;
        HealthBarUIHandler.instance.SetHealthBar(health, maxHealth);

        Controller controller = this.GetComponent<Controller>();
        controller.enabled = false;

        PlayerAttacking attack = this.GetComponent<PlayerAttacking>();
        attack.enabled = false;

        this.enabled = false;

        onPlayerDeath.Invoke();

    }
}
