using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid = null;
    float asteroidRadius;
    float screenWidth;
    float screenHeight;

    const float MinImpulseForce = 1f;
    const float MaxImpulseForce = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // Save asteriod's radious
        GameObject asteroid =  Instantiate<GameObject>(prefabAsteroid);
        CircleCollider2D collider = asteroid.GetComponent<CircleCollider2D>();
        asteroidRadius = collider.radius;
        Destroy(asteroid);

        // Calculate screen width and height
        screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        SpawnRightSideAsteroid();
        SpawnLeftSideAsteroid();
        SpawnUpSideAsteroid();
        SpawnDownSideAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRightSideAsteroid()
    {
        // Set random angle based on direction
        float angle = Random.Range(-30f, 30f) * Mathf.Deg2Rad + -15 * Mathf.Deg2Rad;
               
        // Apply impulse force to get asteroid moving
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(moveDirection * magnitude, 
            new Vector2(ScreenUtils.ScreenRight + asteroidRadius,
                ScreenUtils.ScreenBottom + screenHeight / 2));
    }

    void SpawnUpSideAsteroid()
    {
                // Set random angle based on direction
        float angle = Random.Range(-30f, 30f) * Mathf.Deg2Rad + 75 * Mathf.Deg2Rad;

        // Apply impulse force to get asteroid moving
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(moveDirection * magnitude,  
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenTop + asteroidRadius));
    }

    void SpawnLeftSideAsteroid()
    {
                // Set random angle based on direction
        float angle = Random.Range(-30f, 30f) * Mathf.Deg2Rad + 165 * Mathf.Deg2Rad;

        // Apply impulse force to get asteroid moving
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(moveDirection * magnitude, 
            new Vector2(ScreenUtils.ScreenLeft - asteroidRadius,
                ScreenUtils.ScreenBottom + screenHeight / 2));
    }

    void SpawnDownSideAsteroid()
    {
                // Set random angle based on direction
        float angle = Random.Range(-30f, 30f) * Mathf.Deg2Rad + 255 * Mathf.Deg2Rad;

        // Apply impulse force to get asteroid moving
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(magnitude * moveDirection, 
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenBottom - asteroidRadius));
    }
}
