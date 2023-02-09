using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private Area[] areas;

    [SerializeField] private string levelName;

    private int currentArea = 0;

    public static Level instance;


    void Awake()
    {
        instance = this;
        foreach(Area area in areas){
            area.Init();
            area.Desactivate();
        }
        areas[currentArea].Activate(GameObject.Find("Player").transform);
    }

    public Area GetCurrentArea(){
        return areas[currentArea];
    }

    public void NextArea(){
        currentArea++;
        if(currentArea==areas.Length){
            SaveManager.instance.AddCompletedLevel(levelName);
            SceneManager.LoadScene("LevelSelect");
        }else{
            areas[currentArea-1].Desactivate();
            areas[currentArea].Activate(GameObject.Find("Player").transform);
        }
    }
}
