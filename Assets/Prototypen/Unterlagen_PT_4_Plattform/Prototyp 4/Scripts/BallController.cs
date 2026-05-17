using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Bewegungsgeschwindigkeit
    public float speed;

    // Kraft mit welcher Gegener bei
    // aktiven PowerUp zurückgeschleudert werden
    public float knockbackPower;

    // Wie lange bleibt ein Powerup aktiv
    public float powerupCooldown;

    // Objekt das zeigt ob gerade ein Powerup 
    // aktiv oder nicht ist
    public GameObject indicator;

    // Rigidbody des Spielers
    private Rigidbody playerRb;

    // Kamera-Root
    private GameObject focalPoint;

    // Ist ein PowerUp aktiv
    private bool hasPowerup;

    // Start is called before the first frame update
    void Start()
    {
        // Referenzen zum Rigidbody und der Kamera herstellen
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");

        // Mauszeiger verstecken
        Cursor.lockState = CursorLockMode.Locked;

        // Powerup Indicator ausblenden
        indicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput * Time.deltaTime);

        indicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        // Powerup eingesammelt?
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            
            indicator.SetActive(true);

            CancelInvoke();
            Invoke("DeactivatePowerup", powerupCooldown);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Kollision mit Gegner
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            // Richtungsvektor der vom Spieler wegzeigt
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRb.AddForce(awayFromPlayer * knockbackPower, ForceMode.Impulse);
        }
    }

    private void DeactivatePowerup()
    {
        hasPowerup = false;
        indicator.SetActive(false);
    }
}
