using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f; // Snelheid van de vijand
    public float leftBoundary = -5f; // Linker grens (relatief aan startpositie)
    public float rightBoundary = 5f; // Rechter grens (relatief aan startpositie)
    public float turnMargin = 0.5f; // Marge voordat de vijand omdraait

    private bool movingRight = true; // Geeft aan of de vijand naar rechts beweegt
    private Vector3 startPosition; // Startpositie van de vijand

    private void Start()
    {
        // Sla de startpositie op
        startPosition = transform.position;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // Controleer of de vijand de rechter grens met marge heeft bereikt
            if (transform.position.x >= startPosition.x + rightBoundary - turnMargin)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            // Controleer of de vijand de linker grens met marge heeft bereikt
            if (transform.position.x <= startPosition.x + leftBoundary + turnMargin)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Spiegelt de vijand
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        // Teken visuele hulplijnen voor de linker- en rechtergrenzen in de Editor
        Gizmos.color = Color.red;
        Vector3 leftPoint = startPosition + Vector3.right * leftBoundary;
        Vector3 rightPoint = startPosition + Vector3.right * rightBoundary;
        Gizmos.DrawLine(leftPoint, rightPoint);

        // Teken marges
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(leftPoint + Vector3.right * turnMargin, 0.1f);
        Gizmos.DrawSphere(rightPoint - Vector3.right * turnMargin, 0.1f);
    }
}
