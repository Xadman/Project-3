using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab; // creaated obstacle object

    public Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2; // delaying object spawn
    private float repeatRate = 2; // adding space in between spawns
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>(); // player will restart where it is placed in scene

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // re spawning obstacle after start
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle() //create spawn method
    {
        if (playerControllerScript.gameOver == false) // if play stops game over
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); //cloneing original obsticle to stop

        }
    }

}


