using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int pointValue = 1;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Collision Detected");
        // Check if player touched this collectible
        if (collider.CompareTag("Player"))
        {
            // Find the game manager and increase score
            GameLoopManager manager = FindFirstObjectByType<GameLoopManager>();
            if (manager != null)
            {
                manager.score += pointValue;
            }

            Debug.Log("Collected! Score: " + manager.score);

            Destroy(gameObject);
        }
    }
}