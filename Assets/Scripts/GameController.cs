using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
   
    public Text timeText;    
    public float timer = 0.0f;

    void Update()
    {
        timeUpdate();
    }

    void timeUpdate()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        int min = (int)timer / 60;
        timeText.GetComponent<UnityEngine.UI.Text>().text = min.ToString("00") + ":" + seconds.ToString("00");
    }


}
