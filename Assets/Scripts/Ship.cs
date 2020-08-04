using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
    // private Rigidbody2D rigidbody2D;
    private Vector2 thrustDirection;
    private float thrustForce = 1f;
    private CapsuleDirection2D direction;
    private Vector2 size;
    private float rotateDegreesPerSecond = 20f;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody2D = GetComponent<Rigidbody2D>();
        thrustDirection = new Vector2(1.0f, 0.0f);
        CapsuleCollider2D capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        direction = capsuleCollider2D.direction;
        size = capsuleCollider2D.size;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = 0;
        if (Input.GetAxis("Rotate") > 0)
        {
            rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
        } else if (Input.GetAxis("Rotate") < 0)
        {
            rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
            rotationAmount *= -1;
        }
        transform.Rotate(Vector3.forward, rotationAmount);
        float angle_in_rad = Mathf.Deg2Rad * transform.eulerAngles.z;
        thrustDirection = new Vector2(Mathf.Cos(angle_in_rad), Mathf.Sin(angle_in_rad));
    }

    void FixedUpdate() {

        if (Input.GetAxis("Thrust") > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(thrustForce * thrustDirection);
        }
    }
}
