using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletLifeTime = 2f;
    Timer bulletLifeTimer;
    GameObject thisBullet;
    GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
        thisBullet = GetComponent<GameObject>();
        GameObject[] ship = GameObject.FindGameObjectsWithTag("Ship");
        foreach (GameObject obj in ship)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        GameObject[] otherBullet = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject obj in ship)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        // start spawn timer
        bulletLifeTimer = gameObject.AddComponent<Timer>();
        bulletLifeTimer.Duration = bulletLifeTime;
        bulletLifeTimer.Run();

        hud = GameObject.FindGameObjectsWithTag("HUD")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletLifeTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Asteroid")
        {
            HUD hudScript = (HUD) hud.GetComponent(typeof(HUD));
            hudScript.UpdateScore(1);
            Destroy(coll.gameObject);
            //Destroy(gameObject);
        }
    }
}
