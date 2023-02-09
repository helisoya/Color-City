using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float speed;
    private bool inAlertMode = false;


    private float waitTime = 0;
    [SerializeField] private float maxWaitTime;

    [SerializeField] private FieldOfView fov;

    [SerializeField] private Animator animator;

    [HideInInspector] public Area area;

    private Vector3 startPos;

    void Awake(){
        agent.speed = speed;
        startPos = transform.position;
    }

    void Update()
    {

        if(fov.canSeePlayer){
            transform.LookAt(fov.playerRef.transform.position);
            animator.SetBool("Walking",true);
            agent.SetDestination(fov.playerRef.transform.position);
            inAlertMode = true;
            waitTime = maxWaitTime;
        }

        if(agent.remainingDistance <= 1){
            animator.SetBool("Walking",false);
            if(waitTime>0){
                waitTime-=Time.deltaTime;  
            }else{
                animator.SetBool("Walking",true);
                waitTime = maxWaitTime;
                if(inAlertMode){
                    inAlertMode = false;
                }else{
                    agent.SetDestination(area.GetRandomWaypoint().position);
                }
            }
        }
    }

    public void SetDestination(Vector3 dest){
        agent.SetDestination(dest);
        animator.SetBool("Walking",true);
    }
    public void Reset(){
        agent.enabled = true;
        inAlertMode = false;
        waitTime = 0;
        agent.Warp(startPos);
        agent.SetDestination(startPos);
        agent.isStopped = false;
        animator.SetBool("Walking",false);
        animator.SetBool("Dead",false);
    }
}
