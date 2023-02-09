using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Collider colider;

    [SerializeField] private Animator animator;

    private int maxHealth;

    void Start(){
        maxHealth=health;
    }
    
    public void TakeDamage(){
        health--;
        if(health<=0){
            colider.enabled=false;
            animator.SetBool("Dead",true);
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<EnnemyMovement>().enabled = false;
            GetComponent<EnnemyShoot>().enabled = false;
            GetComponent<EnnemyMovement>().area.RemoveEnnemy();
        }
    }

    public void Reset(){
        health=maxHealth;
        colider.enabled=true;
    }
}
