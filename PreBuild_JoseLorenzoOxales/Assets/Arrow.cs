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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spin");
        assignedArrow = Random.Range(0, sprites.Length - 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            StopCoroutine("spin");
            arrow.sprite = sprites[assignedArrow];

            if (!isInverted)
            {
                arrow.color = Color.green;
            }
            else if (isInverted)
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
    }

        IEnumerator spin()
    {
        while (!inRange)
        {
            yield return new WaitForSeconds(0.3f);
            arrow.sprite = sprites[Random.Range(0, sprites.Length - 1)];
        }
    }
}
