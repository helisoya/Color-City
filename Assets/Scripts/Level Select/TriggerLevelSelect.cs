using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelSelect : MonoBehaviour
{
    void OnTriggerEnter(Collider col){
        if(col.tag=="Player"){
            LevelSelectUI.instance.SelectLevel(gameObject.name);
        }
    }

    void OnTriggerExit(Collider col){
        if(col.tag=="Player"){
            LevelSelectUI.instance.IsShown(false);
        }
    }
}
