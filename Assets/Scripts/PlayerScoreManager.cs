using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    public int score = 0;
    public float sizeIncreaseAmount = 0.1f; // Amount to increase player size on each collectible

    public void IncreaseScore()
    {
        // Increase score
        score++;
        Debug.Log("Score: " + score);

        // Increase player size
        IncreasePlayerSize();
    }

    private void IncreasePlayerSize()
    {
        // Increase the player's scale by a set amount
        transform.localScale += Vector3.one * sizeIncreaseAmount;
    }
}
