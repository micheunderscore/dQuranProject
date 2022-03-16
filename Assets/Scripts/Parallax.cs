using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Parallax : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 startPosition;

    public GameObject foreground;
    public GameObject duplicate;


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(translation:Vector3.left*speed*Time.deltaTime);

        if (transform.position.x > -72 && transform.position.x < -74 )
        {
            duplicate = Instantiate(foreground, new Vector3(37, 0, 0), Quaternion.identity);
        }

        if (transform.position.x == -110.99)
        {
            Destroy (duplicate);
            transform.position = startPosition;
        }
    }
}

   
