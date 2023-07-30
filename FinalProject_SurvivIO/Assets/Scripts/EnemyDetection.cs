using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] public GameObject Enemy;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() || collision.gameObject.GetComponent<EnemyControl>()) 
        {
            
            Enemy.GetComponent<EnemyControl>().target = collision.gameObject;
            Enemy.GetComponent<EnemyControl>().PlayerDetected(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() || collision.gameObject.GetComponent<EnemyControl>())
        {
            Enemy.GetComponent<EnemyControl>().PlayerDetected(false);
        }
    }
}
