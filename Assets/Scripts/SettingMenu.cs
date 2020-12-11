using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool sound;
    public Text lastScore;
    public Text lastTime;
    SaveManager data;



    private void Start()
    {
        data = new SaveManager();
        data.LoadData();
        LoadDataToLabels();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }
    public void ToggleVolume(bool sound)
    {
        if (sound)
        {
            audioMixer.SetFloat("volume", 0);
        }
        else
        { 
            audioMixer.SetFloat("volume", -80); 
        }
    }
    public void LoadDataToLabels()
    {

        lastTime.text = "Time : " + data.gameSaving.time;
        lastScore.text = "Score : " + data.gameSaving.score;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

}
