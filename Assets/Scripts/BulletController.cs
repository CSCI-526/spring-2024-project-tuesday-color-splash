using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 moveDirection = Vector2.right;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime * 5);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        BreakController breakableObstacle = other.gameObject.GetComponent<BreakController>();
        ObstacleController obstacle = other.gameObject.GetComponent<ObstacleController>();
        if (breakableObstacle != null)
        {
            breakableObstacle.Break();  // break the wall
        }
        if (obstacle != null)
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyBullet()
    {
        Destroy(this.gameObject, 2f); // bullets disappear after 3 seconds
    }
}
