using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orc : MonoBehaviour
{
    public Transform player;
    public Transform [] wayPoints;
    private int routeIndex;
    private NavMeshAgent agent;
    private bool playerDetected;
    private SpriteRenderer sprite;
    private Transform objective;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        float distance = Vector3.Distance(player.position, this.transform.position);
        if (this.transform.position == wayPoints[routeIndex].position)
        {
            if (routeIndex < wayPoints.Length - 1) 
            {
            routeIndex++;
            }
            else if(routeIndex == wayPoints.Length - 1)
            {
            routeIndex = 0;
            }
        }

        if (distance < 3)
        {
        playerDetected = true;
        }

        OrcMovement(playerDetected);
        RotateOrc();
        
    }

    void OrcMovement(bool isDetected)
    {
    if (isDetected) 
        {
         agent.SetDestination(player.position);
            objective = player;
        }
        else
        {
            agent.SetDestination(wayPoints[routeIndex].position);
            objective = wayPoints[routeIndex];
        }

    }

    void RotateOrc()
    {
     if (this.transform.position.x > objective.position.x) 
        {
             
            transform.localScale = new Vector2(-1, 1);
        }
        else 
        {
        
             transform.localScale = new Vector2(1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            anim.SetTrigger("Attack");
        }

    }
}
