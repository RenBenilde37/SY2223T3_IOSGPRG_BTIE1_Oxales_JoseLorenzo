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

        if (playerInput.GetComponent<PlayerController>().InputState == collision.gameObject.GetComponent<Arrow>().assignedArrow || playerInput.GetComponent<PlayerController>().isDash)
        {
            SpawnManager.Instance.RemoveEnemyFromList(collision.gameObject);
            Destroy(collision.gameObject);

            powerup.RollPowerUp();

            if (!playerInput.GetComponent<PlayerController>().isDash)
            {
                playerInput.GetComponent<PlayerController>().AddScore(20);
            }

            else if (playerInput.GetComponent<PlayerController>().isDash)
            {
                playerInput.GetComponent<PlayerController>().AddScore(35);
            }

        }

        else if(playerInput.GetComponent<PlayerController>().InputState != collision.gameObject.GetComponent<Arrow>().assignedArrow && !playerInput.GetComponent<PlayerController>().isDash)
        {
            playerInput.GetComponent<PlayerController>().health.DamageHealth(1);
            playerInput.GetComponent<PlayerController>().UpdateLivesCounter();
        }
    }
}

