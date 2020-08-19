using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid = null;
    float asteroidRadius;
    float screenWidth;
    float screenHeight;

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
        SpawnBottomSideAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRightSideAsteroid()
    {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Left, 
            new Vector2(ScreenUtils.ScreenRight + asteroidRadius,
                ScreenUtils.ScreenBottom + screenHeight / 2));
    }

    void SpawnUpSideAsteroid()
    {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Down, 
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenTop + asteroidRadius));
    }

    void SpawnLeftSideAsteroid()
    {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Right, 
            new Vector2(ScreenUtils.ScreenLeft - asteroidRadius,
                ScreenUtils.ScreenBottom + screenHeight / 2));
    }

    void SpawnBottomSideAsteroid()
    {
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Up, 
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenBottom - asteroidRadius));
    }
}
