using UnityEngine;

/// <summary>
/// Controller für Enless-Runner mit Sprung-Mechanik
/// </summary>
public class JumpCharacterController : MonoBehaviour
{
    // Sprungstärke
    public float jumpStrength = 10;

    // Multiplikator um die Graviation zu erhöhen
    public float gravityModifier = 2;

    // Referenz zum Explosions-Partikel-System
    public ParticleSystem explosionParticleSystem;

    // Referenz zum Staub-Partikel-System
    public ParticleSystem dirtParticleSystem;

    // Audio-Clip für Sprung
    public AudioClip jumpSound;

    // Audio-Clip für Zusammenstoß
    public AudioClip crashSound;

    // Referenz zur Rigidbody-Komponente
    private Rigidbody playerRb;

    // Referenz zur Animator-Komponente
    private Animator playerAnimator;

    // Referenz zur Audio-Source
    private AudioSource playerAudioSource;

    // Befindet sich der Spieler auf dem Boden?
    private bool isGrounded = true;

    // Ist der Spieler GameOver?
    private static bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Rigibody-, Animator- und AudioSourc-Komponente auf GameObject suchen 
        // und in Variablen speichern
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudioSource = GetComponent<AudioSource>();

        // Graviation um einen Faktor zu erhöhen
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Soll gesprungen werden?
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver) 
        {
            // Impulse für Sprung
            playerRb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            isGrounded = false;
            
            // Animation abspielen
            playerAnimator.SetTrigger("Jump_trig");
            
            // Sound abspielen
            playerAudioSource.PlayOneShot(jumpSound);
        }
    }

    // Collision mit dem Boden oder einem Hindernis?
    void OnCollisionEnter(Collision collision)
    {
        // Kollision mit dem Boden?
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        } 
        // Kollision mit einem Hindernis?
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.LogError("GAME OVER!!!");
            isGameOver = true;

            // Animation abspielen
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            // PartikelSystem steuern
            explosionParticleSystem.Play();
            dirtParticleSystem.Stop();

            // Sound abspielen
            playerAudioSource.PlayOneShot(crashSound);
        }        
    }

    /// <summary>
    /// Ist das Spiel "Game Over" ?
    /// </summary>
    /// <returns>true = Game Over</returns>
    public static bool IsGameOver() 
    {
        return isGameOver;
    }
}
