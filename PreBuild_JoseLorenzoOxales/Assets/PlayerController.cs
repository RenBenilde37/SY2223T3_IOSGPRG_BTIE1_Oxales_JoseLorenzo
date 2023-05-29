using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;

    public float swipeDeadzone = 10;
    private Vector2 touchInputStart;
    private Vector2 touchInputEnd;

    public int InputState = 4;

    public GameObject attackBox;

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        attackBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                touchInputStart = Input.GetTouch(i).position;
            }


            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                touchInputEnd = Input.GetTouch(i).position;

                Vector2 distance = touchInputEnd - touchInputStart;


                if (Vector2.Distance(touchInputEnd, touchInputStart) > swipeDeadzone)
                {

                    if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
                    {
                        if (touchInputStart.x < touchInputEnd.x)
                        {
                            Debug.Log("Swiped Right");
                            InputState = 3;
                        }

                        else if (touchInputStart.x > touchInputEnd.x)
                        {
                            Debug.Log("Swiped Left");
                            InputState = 2;
                        }
                    }

                    else
                    {
                        if (touchInputStart.y < touchInputEnd.y)
                        {
                            Debug.Log("Swiped Up");
                            InputState = 0;
                        }

                        else if (touchInputStart.y > touchInputEnd.y)
                        {
                            Debug.Log("Swiped Down");
                            InputState = 1;
                        }
                    }

                    attack();
                }

                else
                {
                    Debug.Log("Tapped");
                }
            }
        }
    }

    void FixedUpdate()
    {
        //Keep moving player forward
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    public void attack()
    {
        StartCoroutine("attackCoroutine");
    }

    private IEnumerator attackCoroutine()
    {
        attackBox.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        attackBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Die or Take Damage
        }
    }
}
