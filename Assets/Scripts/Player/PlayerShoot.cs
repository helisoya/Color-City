using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlarePrefab;
    [SerializeField] private Transform barrel;

    private float cooldown = 0;
    [SerializeField] private float maxCooldown;

    [SerializeField] private LayerMask layerToUse;
    void Update()
    {
        if(cooldown>0){
            cooldown-=Time.deltaTime;
        }else{
            if(Input.GetMouseButton(0)){
                Fire();
            }
        }
    }

    void Fire(){
        cooldown = maxCooldown;
        GameObject muzzleFlare = Instantiate(muzzleFlarePrefab,barrel);
        Destroy(muzzleFlare,2);

        RaycastHit hit;
        if(Physics.Raycast(barrel.position,barrel.forward,out hit,300f,layerToUse)){
            if(hit.collider.tag == "Ennemy"){
                if(hit.collider.GetComponent<NavMeshAgent>().enabled){
                    hit.collider.GetComponent<EnnemyMovement>().SetDestination(transform.position);
                }
                hit.collider.GetComponent<EnnemyHealth>().TakeDamage();
            }
        }
    }
}
