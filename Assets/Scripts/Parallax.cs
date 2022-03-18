using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Parallax : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 startPosition;
    private Vector3 recordPosition;

    void Start()
    {
        startPosition = transform.position;
        Debug.Log("Your start position is " + startPosition );
    }

    void Update()
    {
        transform.Translate(translation:Vector3.left*speed*Time.deltaTime);

        if (transform.position.x <= -136.53f )
        {   
            recordPosition = transform.position;

            Debug.Log("Go Away " + recordPosition);

            transform.position = startPosition;

        }

    }
}

   
