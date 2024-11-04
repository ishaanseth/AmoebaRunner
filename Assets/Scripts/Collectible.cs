using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the collectible
        if (other.CompareTag("Player"))
        {
            // Find the PlayerScoreManager component on the player
            PlayerScoreManager scoreManager = other.GetComponent<PlayerScoreManager>();

            if (scoreManager != null)
            {
                // Increase the score
                scoreManager.IncreaseScore();
            }

            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
