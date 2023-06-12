using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float dashSpeed = 20f;
    public float dashCooldown = 5f;

    float dashRegen;

    public float swipeDeadzone = 10;
    private Vector2 touchInputStart;
    private Vector2 touchInputEnd;

    public int InputState = 5;

    public Health health = new Health(1, 3);

    public GameObject attackBox;
    public GameObject sprite;

    public Image dashBar;

    public TextMeshProUGUI livesText;

    int score;
    public TextMeshProUGUI scoreText;

    public bool isDead;
    public bool isDash;
    public bool isDashAvailable;

    // Start is called before the first frame update
    void Start()
    {
        attackBox.SetActive(false);
        isDead = false;
        isDash = false;
        isDashAvailable = true;

        dashRegen = dashCooldown;

        UpdateLivesCounter();
        scoreText.text = "Score: 0";
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

                    attack(0.1f, false);
                }

                else
                {
                    Debug.Log("Tapped");
                    if (isDashAvailable)
                        attack(0.3f, true);
                }
            }
        }

        if (dashRegen < dashCooldown)
        {
            dashRegen += 1 * Time.deltaTime;
            dashBar.fillAmount = dashRegen / dashCooldown;
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

        if (isDashAvailable && isDash)
        {
            this.isDash = true;
            isDashAvailable = false;
            speed = dashSpeed;
            dashRegen = 0;
            StartCoroutine(CO_DashCooldown(dashCooldown));
        }

        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
        attackBox.SetActive(false);
        this.isDash = false;
    }

    private IEnumerator CO_DashCooldown(float duration)
    {
        yield return new WaitForSeconds(duration);
        isDashAvailable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health.HealthComponent > 0)
        {
            health.DamageHealth(1);
            UpdateLivesCounter();
        }

        else if (health.HealthComponent == 0)
            Die();
    }

    public void Die()
    {
        sprite.SetActive(false);
        speed = 0f;
        isDead = true;
    }

    public void UpdateLivesCounter()
    {
        livesText.text = "Lives: " + health.HealthComponent.ToString();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score.ToString(); 
    }
}
