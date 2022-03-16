using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public int LifeMax;
    public float LifeCurrent; 
    public Image imgLifeBar;

    void Start()
    {
        LifeCurrent= LifeMax;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
    }


    public void UpdateLife()
    {
        imgLifeBar.fillAmount= LifeCurrent/ LifeMax;
    }
}
