using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    [SerializeField] Image arrow;
    [SerializeField] Sprite[] sprites;

    public int assignedArrow;
    public bool inRange = false;

    public bool isInverted;
    public bool isCycling;

    // Start is called before the first frame update
    void Start()
    {
        if (isCycling)
        {
            StartCoroutine("CO_Spin");
            arrow.color = Color.yellow;
        }

        assignedArrow = Random.Range(0, sprites.Length - 1);

        if (!isInverted && !isCycling)
        {
            arrow.color = Color.green;
            arrow.sprite = sprites[assignedArrow];
        }
        else if (isInverted && !isCycling)
        {
            arrow.color = Color.red;
            if (assignedArrow == 0)
                arrow.sprite = sprites[1];
            else if (assignedArrow == 1)
                arrow.sprite = sprites[0];
            else if (assignedArrow == 2)
                arrow.sprite = sprites[3];
            else if (assignedArrow == 3)
                arrow.sprite = sprites[2];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player"))
        {
            inRange = true;

            if (isCycling)
            {
                StopCoroutine("CO_Spin");
                arrow.sprite = sprites[assignedArrow];
                arrow.color = Color.green;
            }
        }
    }

    IEnumerator CO_Spin()
    {
        while (!inRange)
        {
            yield return new WaitForSeconds(0.3f);
            arrow.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        }
    }

    //Choose whether to keep inRange or just leave Coroutine as a while(true)
}
