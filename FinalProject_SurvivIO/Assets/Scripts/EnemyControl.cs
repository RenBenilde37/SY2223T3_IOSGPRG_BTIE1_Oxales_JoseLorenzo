using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public bool isPlayerDetected;

    public float roamRange;
    public float maxDistance;

    private Vector2 waypoint;
    private Vector2 direction;

    void Start()
    {
        //StartCoroutine("CO_MoveRandomly");
        target = null;
        SetNewPath();
    }

    void FixedUpdate()
    {
        if (isPlayerDetected)
        {
            direction = target.transform.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);   //Look at Player Maths

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        else if (!isPlayerDetected)
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y); //Look at Path
            direction = waypoint - currentPosition;
            transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);

            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);

            if (Vector2.Distance(currentPosition, waypoint) < roamRange)
            {
                SetNewPath();
            }
        }
    }

    public void PlayerDetected(bool detection)
    {
        isPlayerDetected = detection;
    }

    private void SetNewPath() 
    {
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
}
