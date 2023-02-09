using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnd : MonoBehaviour
{
    void OnTriggerEnter(Collider col){
        if(col.tag=="Player"){
            SaveManager.instance.SetTutorialCompleted(true);
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
