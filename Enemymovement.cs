using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed = 2f;    // Hoe snel de vijand beweegt
    public float moveRange = 5f;    // Hoe ver de vijand beweegt naar links en rechts
    private Vector3 startPosition;  // Startpositie van de vijand

    // Verwijzing naar het GameOverManager script
    public GameOverManager gameOverManager;

    private void Start()
    {
        startPosition = transform.position;   // Sla de startpositie van de vijand op
    }

    private void Update()
    {
        // Laat de vijand heen en weer bewegen tussen twee punten met behulp van PingPong
        float movement = Mathf.PingPong(Time.time * moveSpeed, moveRange);
        transform.position = new Vector3(startPosition.x + movement, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Controleer of de speler in botsing komt met de vijand
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verkrijg de Rigidbody2D component van de speler om de snelheid te controleren
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Controleer of de speler valt (negatieve Y snelheid)
            if (playerRb.linearVelocity.y < 0)
            {
                // Controleer of de positie van de speler boven die van de vijand is (de speler moet bovenop de vijand staan)
                if (collision.transform.position.y > transform.position.y)
                {
                    // De speler valt en is boven de vijand, vernietig de vijand
                    Destroy(gameObject);
                }
            }
            else
            {
                // Als de speler niet valt, trigger dan Game Over
                gameOverManager.GameOver();
            }
        }
    }
}
