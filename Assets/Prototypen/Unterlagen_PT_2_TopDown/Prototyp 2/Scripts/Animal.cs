using UnityEngine;

public class Animal : MonoBehaviour
{
    public float bottomBound = -20;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < bottomBound)
        {
            print("GAME OVER!!!");
        }
    }

    // Berührung mit anderem GameObject (Futter)
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
