using UnityEngine;

public class TempGameOver : MonoBehaviour
{
    [SerializeField]private PlayerLife playerLife;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerLife != null)
        {
            playerLife.onPlayerDeath.AddListener(GameOver);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.LogWarning("Game Over");
    }
}
