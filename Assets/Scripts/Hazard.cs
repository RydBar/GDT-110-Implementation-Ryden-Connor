using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damageAmount = 20;

    private PlayerHealth playerHealth;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {

            playerHealth = collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

        }
    }
}