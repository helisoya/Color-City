using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;

    private SAVEFILE save = new SAVEFILE();

    void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
            instance = this;
            Load();
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public bool HasDoneTutorial(){return save.tutorialCompleted;}

    public void SetTutorialCompleted(bool value){
        save.tutorialCompleted = value;
        Save();
    }

    public bool HasCompletedLevel(string level){
        return save.completedLevels.Contains(level);
    }

    public void AddCompletedLevel(string level){
        if(!HasCompletedLevel(level)){
            save.completedLevels.Add(level);
            Save();
        }
    }

    void Save(){
        FileManager.SaveJSON(FileManager.savPath + "save.sav",save);
    }

    void Load(){
        if(System.IO.File.Exists(FileManager.savPath + "save.sav")){
            save = FileManager.LoadJSON<SAVEFILE>(FileManager.savPath + "save.sav");
        }
    }
}
