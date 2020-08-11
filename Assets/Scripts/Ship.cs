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
    private Rigidbody2D rigidbody2d;

    private float rotateDegreesPerSecond = 20f;
    // spawn timing support
    const float SpawnDelaySeconds = 0.2f;
    Timer spawnTimer;

    [SerializeField]
    GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        thrustDirection = new Vector2(1.0f, 0.0f);
        CapsuleCollider2D capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        direction = capsuleCollider2D.direction;
        size = capsuleCollider2D.size;

        rigidbody2d = GetComponent<Rigidbody2D>();

        // start spawn timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = SpawnDelaySeconds;
        spawnTimer.Run();
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

        if (Input.GetAxis("Fire") > 0 && spawnTimer.Finished)
        {
            spawnTimer.Run();
            Vector2 direction = new Vector2(Mathf.Cos(angle_in_rad), Mathf.Sin(angle_in_rad));
            Vector3 direction3 = new Vector3(direction.x, direction.y, 0);
            Vector2 position = new Vector3(transform.position.x, transform.position.y, transform.position.z) + 3 * direction3;
            GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();
          //  bulletRigidbody2D.velocity = GetComponent<Rigidbody2D>().
            bulletRigidbody2D.AddForce(10 * direction, ForceMode2D.Impulse);    
        }
    }

    void FixedUpdate() {
        if (Input.GetAxis("Thrust") > 0)
        {
            GetComponent<Rigidbody2D>().AddForce(thrustForce * thrustDirection);
        }
    }
}
