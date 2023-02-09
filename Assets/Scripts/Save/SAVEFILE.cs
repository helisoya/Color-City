using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SAVEFILE
{
    public List<string> completedLevels;

    public bool tutorialCompleted;

    public SAVEFILE(){
        tutorialCompleted = false;
        completedLevels = new List<string>();
    }
}
