using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float dashSpeed = 20f;

    public float swipeDeadzone = 10;
    private Vector2 touchInputStart;
    private Vector2 touchInputEnd;

    public int InputState = 5;

    public GameObject attackBox;
    public GameObject sprite;

    public bool isDead;
    public bool isDash;

    // Start is called before the first frame update
    void Start()
    {
        attackBox.SetActive(false);
        isDead = false;
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

                    attack(0.3f, false);
                }

                else
                {
                    Debug.Log("Tapped");

                    attack(0.3f, true);
                }
            }
        }
    }

    void FixedUpdate()
    {
        //Keep moving player forward
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    public void attack(float duration, bool isDash)
    {
        StartCoroutine(CO_Attack(duration, isDash));
    }

    private IEnumerator CO_Attack(float duration, bool isDash)
    {
        float originalSpeed;
        originalSpeed = speed;

        attackBox.SetActive(true);
        this.isDash = isDash;

        if (isDash)
            speed = dashSpeed;

        yield return new WaitForSeconds(duration);
        this.isDash = false;
        speed = originalSpeed;
        attackBox.SetActive(false);
    }


    //Player Death
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprite.SetActive(false);
        speed = 0f;
        isDead = true;
    }
}
