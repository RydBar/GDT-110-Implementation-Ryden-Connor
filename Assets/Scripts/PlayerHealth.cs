using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    private GameLoopManager gameManager; //the script, not found yet
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        gameManager = FindFirstObjectByType<GameLoopManager>(); //references? the script

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("PlayerHealth: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player Died");
        gameManager.currentState = GameLoopManager.GameState.GameOver; //Sets to GameOver state
    }
}
