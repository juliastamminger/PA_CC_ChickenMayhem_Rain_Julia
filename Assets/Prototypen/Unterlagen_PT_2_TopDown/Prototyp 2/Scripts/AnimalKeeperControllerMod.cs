using UnityEngine;

/// <summary>
/// Die Spielersteuerung des 2. Prototypen inklusive Mods
/// </summary>
public class AnimalKeeperControllerMod : MonoBehaviour
{
    // Bewegungsgeschwindigkeit
    public float speed = 5;

    // Min und Max für Bewegung in x-Richtung
    public float xRange = 15;

    //Max für Bewegung in z-Richtung
    public float zRange = 5;

    // Prefab des Projektils
    public GameObject projectilePrefab;

    private bool hasPowerUp;

    // Update is called once per frame
    void Update()
    {   
        // Eingabeen
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Vektor basierend auf den Eingaben
        Vector3 input = new Vector3(horizontalInput, 0, verticalInput);
        
        // Länge des Eingabe-Vektors
        float magnitude = Mathf.Clamp01(input.magnitude);

        // Verschieden der Spielfigur
        transform.Translate(input.normalized * magnitude * speed * Time.deltaTime);

        // Bewegung in x- und z-Richtung beschränken
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        float clampedZ = Mathf.Clamp(transform.position.z, 0, zRange);

        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        // PowerUp eingesammelt?
        if (hasPowerUp) 
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetButton("Jump"))
            {
                // WICHTIG: Die Projektile vor der Spielfigur erzeugen,
                // damit diese nicht von der OnTriggerEnter-Methode erfasst werden!
                // Hier 2 Meter vor der Figur, durch Addition eines Vektors (0,0,2)
                Instantiate(projectilePrefab, transform.position + new Vector3(0, 0, 2), transform.rotation);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            {
                // WICHTIG: Die Projektile vor der Spielfigur erzeugen,
                // damit diese nicht von der OnTriggerEnter-Methode erfasst werden!
                // Hier 2 Meter vor der Figur, durch Addition eines Vektors (0,0,2)
                Instantiate(projectilePrefab, transform.position + new Vector3(0, 0, 2), transform.rotation);
            }
        }
    }

    /// <summary>
    /// Berührung mit einem anderen Collider?
    /// </summary>
    /// <param name="other">Anderes Objekt mit dem die Berührung stattfand.</param>
    void OnTriggerEnter(Collider other)
    {
        hasPowerUp = true;
        Destroy(other.gameObject);
    }
}
