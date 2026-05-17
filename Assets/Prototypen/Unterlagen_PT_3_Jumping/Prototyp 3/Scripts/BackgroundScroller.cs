using UnityEngine;

/// <summary>
/// Bewegt das Hintergrund-Sprite und setzt
/// es nahtlos aneinander
/// </summary>
public class BackgroundScroller : MonoBehaviour
{
    // Postion des Hintergrunds beim Start
    private Vector3 startPosition;

    // Bewegunsgeschwindigkeit Hintergrund
    public float speed = 30;

    // Distanz ab welcher der Hintergrund zurückgesetzt wird
    // entspricht der Hälfte der BoxCollider-Breite
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Start-Position speichern
        startPosition = transform.position;
        
        // Breite für das Zurücksetzen des Hintergrunds berechnen
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Läuft das Spiel noch?
        if (!JumpCharacterController.IsGameOver()) 
        {
            // Verschiebung des Hintergrunds
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Muss der Hintergrund zurückgesetzt werden?
            if (transform.position.x < startPosition.x - repeatWidth)
            {
                transform.position = startPosition;
            }
        }        
    }
}
