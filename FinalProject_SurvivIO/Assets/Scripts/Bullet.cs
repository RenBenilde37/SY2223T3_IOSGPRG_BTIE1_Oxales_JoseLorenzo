using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Instantiate Hit Effect Here

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "Player")
        Destroy(gameObject);
    }
}
