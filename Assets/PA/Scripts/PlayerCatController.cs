using UnityEngine;

public class PlayerCatController : MonoBehaviour
{
    //normale Geschwindigkeit ohne Boost (Julia)
    private float normalCatSpeed = 10;

    //Geschwindigkeit beim Drehen ohne Boost (Julia)
    private float drehenSpeed = 200;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Bewegung vorwärts,rückwärts (Julia)                                                                      (@Rain: wenn du einen Code geschrieben/verändert hast, schreib doch deinen Namen hinters Kommentar drüber. So ->)(Julia)
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * normalCatSpeed * verticalInput * Time.deltaTime);

        //Bewegung Richtungsänderung "lenken" (Julia)
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate( drehenSpeed * horizontalInput * Time.deltaTime * Vector3.up);

        //Springen?

        //Boost -> Referenz zu Timer

        //Referenz -> Punkte wenn Prey gefangen

        //GameGewonnen -> Timer leer + genug Prey gefangen

        //GameOver -> Referenz zu gefangen von Enemy oder Timer leer + zu wenig Prey gefangen

    }
}
