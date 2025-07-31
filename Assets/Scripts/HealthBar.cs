using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Life playerLife;

    public Transform cameraTransform;
    public Transform healthTransform;

    public TMP_Text text;

    public float healthPercentage;
    public Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        originalPosition = cameraTransform.position + new Vector3(-10f, 8, 10);

        healthPercentage = playerLife.health / playerLife.maxHealth;

        healthTransform.localScale = new Vector3(healthPercentage * 10, healthTransform.localScale.y, healthTransform.localScale.z);
        healthTransform.position = new Vector3(originalPosition.x + healthPercentage * 5f -5, originalPosition.y, originalPosition.z);

        if (healthPercentage > 0.5f)
        {
            sprite.color = Color.green;
        }
        else if (healthPercentage > 0.3f)
        {
            sprite.color = Color.yellow;
        }
        else if (healthPercentage > 0.2f)
        {
            sprite.color = new Color(1.0f, 0.68f, 0.21f, 1.0f);
        }
        else
        {
            sprite.color = Color.red;
        }

        text.text = playerLife.health + "/" + playerLife.maxHealth;
    }
}
