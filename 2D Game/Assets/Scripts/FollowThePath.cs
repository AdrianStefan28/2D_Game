using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private GameObject fox;

    [SerializeField]
    private float moveSpeed = 4f;

    private int waypointIndex = 0;
    public bool canMove;
    public bool canAttack;



    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        canAttack = false;
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }

        if (canAttack)
        {
            Attack();
        }
    }

    private void Move()
    {
        if(waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if(transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

            if(transform.position == waypoints[waypoints.Length - 1].transform.position)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Attack()
    {
        transform.position = Vector3.MoveTowards(transform.position, fox.transform.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canMove = false;
            canAttack = true;
        }

        if(collision.gameObject.tag == "cantAttack")
        {
            canAttack = false;
            canMove = true;
           // Debug.Log("Intra");
        }
    }



}
