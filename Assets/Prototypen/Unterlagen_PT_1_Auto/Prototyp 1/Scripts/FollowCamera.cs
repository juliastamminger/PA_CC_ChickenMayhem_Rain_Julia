using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Einfache Verfolger-Kamera
public class FollowCamera : MonoBehaviour
{
    // Verbindung zum Auto
    public GameObject player;

    // Abstand zum Auto
    public Vector3 offset;


    // Update is called once per frame
    void LateUpdate()
    {
        // Setze die Position dieses GameObjects auf die
        // Position des angegebenen GameObjects (player) und addiere
        // einen Offset (Vector3)
        transform.position = player.transform.position + offset;
    }
}
