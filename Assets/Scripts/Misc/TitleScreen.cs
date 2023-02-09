using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    public void LaunchGame(){
        if(SaveManager.instance.HasDoneTutorial()){
            SceneManager.LoadScene("LevelSelect");
        }else{
            SceneManager.LoadScene("Tutorial");
        }
    }
}
