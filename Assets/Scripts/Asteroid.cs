using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite spriteAsteroid0 = null;

    [SerializeField]
    Sprite spriteAsteroid1 = null;

    [SerializeField]
    Sprite spriteAsteroid2 = null;

    const float MinImpulseForce = 1f;
    const float MaxImpulseForce = 3f;

    // Start is called before the first frame update
    void Start()
    {
        int positionSelection = Random.Range(0, 4);
        switch (positionSelection)
        {
            case 0:
                this.transform.position = new Vector2(ScreenUtils.ScreenLeft, 0);
                break;
            case 1:
                this.transform.position = new Vector2(ScreenUtils.ScreenRight, 0);
                break;
            case 2:
                this.transform.position = new Vector2(0, ScreenUtils.ScreenTop);
                break;
            case 3:
                this.transform.position = new Vector2(0, ScreenUtils.ScreenBottom);
                break;
        }

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        switch (spriteNumber)
        {
            case 0:
                spriteRenderer.sprite = spriteAsteroid0;
                break;
            case 1:
                spriteRenderer.sprite = spriteAsteroid1;
                break;
            case 2:
                spriteRenderer.sprite = spriteAsteroid2;
                break;
        }

        GameObject[] otherAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject obj in otherAsteroids)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ship")
        {
            Destroy(coll.gameObject);
        }
    }

    public void Initialize(Direction direction, Vector3 position)
    {
        // Set asteroid position
        transform.position = position;

        // Set random angle based on direction
        float angle = Random.value * 30f * Mathf.Deg2Rad;
        switch (direction)
        {
            case Direction.Up:
                angle += 75 * Mathf.Deg2Rad;
                break;
            case Direction.Left:
                angle += 165 * Mathf.Deg2Rad;
                break;
            case Direction.Down:
                angle += 255 * Mathf.Deg2Rad;
                break;
            case Direction.Right:
                angle += -15 * Mathf.Deg2Rad;
                break;
        }

        // Apply impulse force to get asteroid moving
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }
}
