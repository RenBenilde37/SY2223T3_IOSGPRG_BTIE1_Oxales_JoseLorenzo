using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Attack attack;

    int extraLives;

    public void AddLife()
    {
        extraLives++;
    }

    public void RollPowerUp()
    {
        int random = Random.Range(0, 100);

        if(random < 3)
        {
            AddLife();
            Debug.Log("Added Life");
        }
    }
}
