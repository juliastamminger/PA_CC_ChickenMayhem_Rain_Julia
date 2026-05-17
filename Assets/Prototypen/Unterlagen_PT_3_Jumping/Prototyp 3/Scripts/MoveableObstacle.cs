using UnityEngine;

/// <summary>
/// Bewegt ein Hindernis im Welt-Koordinatensystem nach links (-x)
/// </summary>
public class MoveableObstacle : MonoBehaviour
{
    // Bewegunsgeschwindigkeit Hindernis
    public float speed = 30;

    // Update is called once per frame
    void Update()
    {
        // Läuft das Spiel noch?
        if (!JumpCharacterController.IsGameOver()) 
        {
            // Verschiebung im WorldSpace
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

            // Hat das Hindernis den Bildschirm verlassen?
            if(transform.position.x < -5) 
            {
                Destroy(gameObject);
            }
        }        
    }
}
