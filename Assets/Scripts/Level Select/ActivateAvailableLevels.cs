using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAvailableLevels : MonoBehaviour
{

    [SerializeField] private GameObject[] levelsRoot;

    void Start()
    {
        for(int i =1;i<levelsRoot.Length;i++){
            levelsRoot[i].SetActive(SaveManager.instance.HasCompletedLevel(levelsRoot[i-1].name));
        }    
    }

}
