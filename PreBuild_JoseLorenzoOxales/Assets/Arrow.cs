using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    [SerializeField] Image arrow;
    [SerializeField] Sprite[] sprites;

    public int assignedArrow;
    bool inRange = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spin");
        assignedArrow = Random.Range(0, sprites.Length - 1);

        arrow.sprite = sprites[assignedArrow];
    }

    // Update is called once per frame
    void Update()
    {

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
