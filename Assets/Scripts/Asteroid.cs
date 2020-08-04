using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite asteroidSprite1;

    [SerializeField]
    Sprite asteroidSprite2;

    [SerializeField]
    Sprite asteroidSprite3;

    // Start is called before the first frame update
    void Start()
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 direction = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            direction * magnitude,
            ForceMode2D.Impulse);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(1, 3);
        switch (spriteNumber)
        {
            case 1:
                spriteRenderer.sprite = asteroidSprite1;
                break;
            case 2:
                spriteRenderer.sprite = asteroidSprite2;
                break;
            case 3:
                spriteRenderer.sprite = asteroidSprite3;
                break;
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
