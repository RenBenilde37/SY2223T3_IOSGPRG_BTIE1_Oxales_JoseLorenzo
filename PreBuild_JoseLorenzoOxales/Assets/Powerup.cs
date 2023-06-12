using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Attack attack;
    public PlayerController player;

    public void RollPowerUp()
    {
        int random = Random.Range(0, 100);

        if(random < 50)
        {
            player.health.Heal(1);
            player.UpdateLivesCounter();
            Debug.Log("Added Life");
        }
    }
}
