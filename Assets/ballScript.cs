using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world");
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name == "WallVertical" || other.collider.name == "WallVertical1")
        {
            GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}


