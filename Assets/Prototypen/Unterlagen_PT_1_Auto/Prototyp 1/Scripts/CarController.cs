using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fahrzeugsteuerung für Prototyp 1
public class CarController : MonoBehaviour
{
    // Fahrzeug-Geschwindigkeit
    public float speed;

    // Lenk-Geschwindigkeit
    public float turnSpeed;


    // Update is called once per frame
    void Update()
    {
        // Speichern der Tastatur-Eingaben (Cursor-Tasten)
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Vorwärtsbewegung des Fahrzeugs
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        // Lenkbewegung des Fahrzeugs
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
    }
}
