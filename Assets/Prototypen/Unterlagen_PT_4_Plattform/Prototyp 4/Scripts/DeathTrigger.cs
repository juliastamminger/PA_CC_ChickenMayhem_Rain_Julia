using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Hat ein Gegner den Collider berührt?
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
