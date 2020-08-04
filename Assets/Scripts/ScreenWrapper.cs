using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
//    private CapsuleDirection2D direction;
//    private Vector2 size;

    // Start is called before the first frame update
    void Start()
    {
//        CapsuleCollider2D capsuleCollider2D = GetComponent<CapsuleCollider2D>();
//        direction = capsuleCollider2D.direction;
//        size = capsuleCollider2D.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        if (position.x < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenRight;
        }
        else if (position.x > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenLeft;
        }

        if (position.y < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenTop;
        }
        else if (position.y > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenBottom;
        }

        transform.position = position;
    }
}
