using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // private Rigidbody2D rigidbody2D;
    private Vector2 thrustDirection;
    private float ThrustForce = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody2D = GetComponent<Rigidbody2D>();
        thrustDirection = new Vector2(1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {

        if (Input.GetAxis("Thrust") > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(ThrustForce * thrustDirection);
        }
    }
}
