using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject playerInput;
    public Powerup powerup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched" + collision.gameObject.name);

        if (playerInput.GetComponent<PlayerController>().InputState == collision.gameObject.GetComponent<Arrow>().assignedArrow)
        {
            Destroy(collision.gameObject);
            SpawnManager.Instance.RemoveEnemyFromList(collision.gameObject);

            powerup.RollPowerUp();
        }
    }

    //to shorten code, include local variables inside function
}

