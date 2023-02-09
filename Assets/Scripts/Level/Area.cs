using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Area
{
    public List<GameObject> ennemies;
    public Transform startPos;
    public GameObject root;

    public GameObject exit;

    private int ennemyCount;

    public void Init(){
        ennemyCount = ennemies.Count;
        foreach(GameObject ennemy in ennemies){
            ennemy.GetComponent<EnnemyMovement>().area=this;
        }
    }

    public Transform[] waypoints;
    public Transform GetRandomWaypoint(){
        return waypoints[Random.Range(0,waypoints.Length)];
    }

    public void Activate(Transform player){
        root.SetActive(true);
        player.position = startPos.position;
    }

    public void Desactivate(){
        root.SetActive(false);
    }

    public void Reset(Transform player){
        exit.SetActive(false);
        ennemyCount = ennemies.Count;
        player.position = startPos.position;
        foreach(GameObject ennemy in ennemies){
            ennemy.GetComponent<EnnemyMovement>().enabled = true;
            ennemy.GetComponent<EnnemyMovement>().Reset();
            ennemy.GetComponent<EnnemyShoot>().enabled = true;
            ennemy.GetComponent<EnnemyShoot>().Reset();
            ennemy.GetComponent<EnnemyHealth>().Reset();
        }
    }

    public void RemoveEnnemy(){
        ennemyCount--;
        if(ennemyCount==0){
            exit.SetActive(true);
        }
    }
}
