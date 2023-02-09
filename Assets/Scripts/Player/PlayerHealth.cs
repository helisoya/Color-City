using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;

    private int maxHealth;
    [SerializeField] private Collider colider;

    [SerializeField] private Animator animator;



    void Start(){
        maxHealth = health;
    }
    
    public void TakeDamage(){
        health--;
        PlayerUI.instance.UpdateHealth(health,maxHealth);
        if(health<=0){
            colider.enabled=false;
            animator.SetBool("Dead",true);
            GetComponent<Rigidbody>().useGravity=false;
            GetComponent<PlayerLaserSight>().enabled = false;
            GetComponent<PlayerShoot>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(CountdownBeforeRestart());
        }
    }

    IEnumerator CountdownBeforeRestart(){
        yield return new WaitForSeconds(2);
        health = maxHealth;
        PlayerUI.instance.UpdateHealth(health,maxHealth);
        colider.enabled=true;
        animator.SetBool("Dead",false);
        animator.SetBool("Walking",false);
        GetComponent<Rigidbody>().useGravity=true;
        GetComponent<PlayerLaserSight>().enabled = true;
        GetComponent<PlayerShoot>().enabled = true;
        GetComponent<PlayerMovement>().enabled = true;
        Level.instance.GetCurrentArea().Reset(transform);
    }
}
