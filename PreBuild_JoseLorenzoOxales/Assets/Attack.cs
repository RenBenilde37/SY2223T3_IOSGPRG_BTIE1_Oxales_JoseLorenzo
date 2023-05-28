using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject playerInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched" + collision.gameObject.name);

        if (playerInput.GetComponent<PlayerController>().GetDirection() == 0)
        {
            Destroy(collision.gameObject);
        }
    }
}

