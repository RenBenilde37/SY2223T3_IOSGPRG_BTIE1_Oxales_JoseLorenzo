using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().isDead)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
