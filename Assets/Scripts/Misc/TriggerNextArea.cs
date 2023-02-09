using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextArea : MonoBehaviour
{

    void OnTriggerEnter(Collider col){
        if(col.tag=="Player"){
            Level.instance.NextArea();
        }
    }
}
