using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject muzzleFlarePrefab;
    [SerializeField] private Transform barrel;

    private float cooldown = 0;
    [SerializeField] private float maxCooldown;

    [SerializeField] private FieldOfView fov;

    [SerializeField] private LayerMask layerToUse;



    void Update()
    {
        if(cooldown>0){
            cooldown-=Time.deltaTime;
        }else{
            if(fov.canSeePlayer){
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
            if(hit.collider.tag == "Player"){
                hit.collider.GetComponent<PlayerHealth>().TakeDamage();
            }
        }
    }

    public void Reset(){
        cooldown = 0;
    }
}
