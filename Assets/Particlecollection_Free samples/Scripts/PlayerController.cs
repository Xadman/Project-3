using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // created field for player
    private Animator playerAnim; // created animation field for player
    private AudioSource playerAudio; // created audio field for scene
    public ParticleSystem explosionParticle; // created variable for object
    public ParticleSystem sprayParticle; // created variable for object
    public AudioClip jumpSound;// created audio field for jump
    public AudioClip crashSound;// created audio field for crash
    public float jumpForce = 10; // created variable for jump force
    public float gravityModifier; // created gravity for player
    public bool isOnGround = true; 
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // calling player at start
        playerAnim = GetComponent<Animator>(); //calling animator for player
        playerAudio = GetComponent<AudioSource>(); //calling audio source to player
        Physics.gravity *= gravityModifier; //calling gravity to player at start

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) // getting input from space bar to jump if on ground
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // calling jump force method
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig"); // setting trigger for particles to stop on jump
            sprayParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.5f); // playing audio clip once per pressing space bar
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // if player is on the ground
        {
            isOnGround = true; // is true
            sprayParticle.Play(); // start spray particle again
        }
        else if (collision.gameObject.CompareTag("Obstacle")) // if player collides with obstacile
        {
            Debug.Log("Game Over"); // print game over
            gameOver = true;// is true
            playerAnim.SetBool("Death_b", true); // calling type of death
            playerAnim.SetInteger("DeathType_int", 1); //calling animation of death
            explosionParticle.Play(); // if collision Boom a cloud of smoke
            sprayParticle.Stop(); // on collision stop spray particle
            playerAudio.PlayOneShot(crashSound, 1.0f); // on collision crash sound one time
        }
    }
}

