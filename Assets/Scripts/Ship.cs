using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // private Rigidbody2D rigidbody2D;
    private Vector2 thrustDirection;
    private float ThrustForce = 1.0f;
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
    }

    void FixedUpdate() {

        if (Input.GetAxis("Thrust") > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(ThrustForce * thrustDirection);
        }
    }

    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        if (position.x < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenRight;
        } else if (position.x > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenLeft;
        }
    
        if (position.y < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop;
        } else if (position.y > ScreenUtils.ScreenTop)
        {
            position.x = ScreenUtils.ScreenBottom;
        }

        transform.position = position;
    }
}
