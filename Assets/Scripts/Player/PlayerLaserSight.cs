using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserSight : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Transform barrel;

    [SerializeField] private LayerMask layerMask;

    private bool laserOn = true;


    void Update()
    {

        if(Input.GetKeyDown(KeyCode.L)){
            laserOn = !laserOn;
            lr.gameObject.SetActive(laserOn);
        }

        if(!laserOn) return;

        RaycastHit hit;


        if(Physics.Raycast(barrel.position,barrel.forward,out hit,500,layerMask)){
            lr.SetPosition(1,new Vector3(0,0,hit.distance));
        }else{
            lr.SetPosition(1,new Vector3(0,0,500));
        }
    }
}
