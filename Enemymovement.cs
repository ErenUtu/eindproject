using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;    // How fast the enemy moves
    public float moveRange = 5f;    // How far the enemy moves left and right
    private Vector3 startPosition;

    // Reference to the GameOverManager script
    public GameOverManager gameOverManager;

    private void Start()
    {
        startPosition = transform.position;   // Record the starting position of the enemy
    }

    private void Update()
    {
        // Make the enemy move back and forth between two points using PingPong
        float movement = Mathf.PingPong(Time.time * moveSpeed, moveRange);
        transform.position = new Vector3(startPosition.x + movement, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is colliding with the enemy
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the player's Rigidbody2D component to check velocity
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Check if the player is falling (negative Y velocity)
            if (playerRb.linearVelocity.y < 0)
            {
                // Check if the player�s position is above the enemy's position (player should be on top)
                if (collision.transform.position.y > transform.position.y)
                {
                    // Player is falling and above the enemy, destroy the enemy
                    Destroy(gameObject);
                }
            }
            else
            {
                // If the player is not falling, trigger Game Over
                gameOverManager.GameOver();
            }
        }
    }
}
