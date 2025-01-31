using UnityEngine;

public class CameraVolgen : MonoBehaviour
{
    public Transform speler; // Verwijzing naar de transform van de speler
    public Vector3 offset;   // Verschil tussen de speler en de camera
    public float soepeleSnelheid = 0.125f; // Pas aan voor een soepelere beweging

    void LateUpdate()
    {
        if (speler != null)
        {
            // Doelpositie op basis van de positie van de speler en de offset
            Vector3 doelPositie = speler.position + offset;

            // Zorg voor een soepele overgang tussen de huidige camera-positie en de doelpositie
            Vector3 soepelePositie = Vector3.Lerp(transform.position, doelPositie, soepeleSnelheid);

            // Werk de camera-positie bij
            transform.position = soepelePositie;
        }
    }
}
