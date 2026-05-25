using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Verbindung mit PlayerCat (Julia)
    public GameObject player;

    //Abstand zu PlayerCat (Julia)
    public Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Position der Kamera dem PlayerCat folgend
        transform.position = player.transform.position + offset;
    }
}
