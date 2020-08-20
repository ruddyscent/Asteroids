using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite spriteAsteroid0 = null;

    [SerializeField]
    Sprite spriteAsteroid1 = null;

    [SerializeField]
    Sprite spriteAsteroid2 = null;

    GameObject hud;

    private int heatCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] otherAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject obj in otherAsteroids)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        hud = GameObject.FindGameObjectsWithTag("HUD")[0];
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
        case "Ship":
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(col.gameObject);
            break;

        case "Bullet":
            AudioManager.Play(AudioClipName.AsteroidHit);
            // Destroy bullet
            Destroy(col.gameObject);

            // Incrase score
            HUD hudScript = (HUD) hud.GetComponent(typeof(HUD));
            hudScript.UpdateScore(1);

            // Destroy asteroid
            heatCount += 1;
            if (heatCount > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.localScale /= 2;

                GameObject fragment = Instantiate(gameObject, transform.position, Quaternion.identity);
                fragment.GetComponent<Asteroid>().heatCount = heatCount;

                // Set movement of new fragment with little perturbation
                Rigidbody2D fargmentRigidbody = fragment.GetComponent<Rigidbody2D>();
                Rigidbody2D originalRigidbody = GetComponent<Rigidbody2D>();

                float minDisturbe = 0.5f;
                float maxDisturbe = 1.5f;
                Vector2 perturbation = new Vector2(Random.Range(minDisturbe, maxDisturbe),
                                                    Random.Range(minDisturbe, maxDisturbe));
                fargmentRigidbody.velocity = perturbation * originalRigidbody.velocity;
            }
            break;
        }
    }

    public void Initialize(Vector2 force, Vector3 position)
    {
        // If the sprite is not given, use a random sprite.
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

        // Set asteroid position
        transform.position = position;

        GetComponent<Rigidbody2D>().AddForce(
            force,
            ForceMode2D.Impulse);
    }
}
