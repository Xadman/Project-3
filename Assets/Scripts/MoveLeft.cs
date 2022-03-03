using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20; // created a variable called speed
    private PlayerController playerControllerScript; // called player controller script
    private float leftBound = -15; // set boundry limit

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); /// player will restart where it is placed in scene
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // lets us set speed of player
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // once obstacle passes player and gets to edge of scene it is destroyed
        {
            Destroy(gameObject);
        }

    }
}