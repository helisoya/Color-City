using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectUI : MonoBehaviour
{
    [SerializeField] private GameObject root;
    private string level;

    public static LevelSelectUI instance;

    void Start(){
        instance = this;
        IsShown(false);
    }
    public void SelectLevel(string levelName){
        IsShown(true);
        level = levelName;
    }

    public void IsShown(bool value){
        root.SetActive(value);
    }


    public void LoadLevel(){
        SceneManager.LoadScene(level);
    }
}
