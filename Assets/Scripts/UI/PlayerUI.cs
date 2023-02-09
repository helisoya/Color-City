using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image health;

    public static PlayerUI instance;
    void Start()
    {
        instance = this;
    }

    public void UpdateHealth(float currentH, float maxH){
        health.fillAmount=currentH/maxH;
    }
}
