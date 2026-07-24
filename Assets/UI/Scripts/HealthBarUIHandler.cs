using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUIHandler : MonoBehaviour
{
    public static HealthBarUIHandler instance {get; private set;}

    UIDocument uIDocument;
    VisualElement healthBar;
    Label healthText;
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uIDocument = GetComponent<UIDocument>();
        healthBar = uIDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        healthText = uIDocument.rootVisualElement.Q<Label>("HealthText");

    }


    public void SetHealthBar(float health, float maxHealth)
    {
        float healthPercentage = (health / maxHealth) * 100;
        healthBar.style.width = Length.Percent(healthPercentage);
        healthText.text = health + " / " + maxHealth;
    }
}
