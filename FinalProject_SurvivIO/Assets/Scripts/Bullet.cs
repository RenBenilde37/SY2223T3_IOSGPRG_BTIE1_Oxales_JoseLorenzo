using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Instantiate Hit Effect Here

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        if (collision.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}
