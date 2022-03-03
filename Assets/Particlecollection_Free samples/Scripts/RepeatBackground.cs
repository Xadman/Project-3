using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos; // created variable for start position of scene
    private float repeatWidth; // created variable for width/length of scene

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // tracking start and position of scene

        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // getting exaxct half point of scene and reproduceing it
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) // calling the start position and repeating the background half point
        {
            transform.position = startPos; 
        }
    }
}
