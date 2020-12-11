using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Ball Movement Oyuncunun vurduğu topu kontrol eder.*/
public class BallMovement : MonoBehaviour
{
    //Vurus siddeti ve skor tutulur. Skor 5'e ulastiginda oyun son bulur.
    float force;
    int score;

    public Text scoreText;
    public Text timeText;
    public Rigidbody[] balls;
    public Strike strike;
    public Image forceSlider;
    public Rigidbody ball;
    public Camera playerCamera;

    SaveManager manager;

    void Start()
    {
        forceSlider.fillAmount = 0;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            if (force < 101)
            {
                force++;
                forceSlider.fillAmount = force / 100;
            }
            if (force == 100)
            {
                for (int i = 101; i > 0; i--)
                {
                    force = i;
                    forceSlider.fillAmount = force / 100;
                }
            } 

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            strike = new Strike(balls);
            if (!strike.isMoving) 
            { 
            ball.velocity = playerCamera.transform.forward * force /2;
            force = 0;
            forceSlider.fillAmount = force; 
            }
        }

        if (strike != null)
        {
            strike.checkMovement();
        }
        updateScore();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Ground")
        {
            if (collision.gameObject.tag == "Ball")
            {
                if (strike.checkCollide(collision.gameObject.name))
                {
                    score++;
                }
            }
            
        }
    }
    void updateScore()
    {
        scoreText.text = score.ToString();
        
        if (score == 5)
        {
            manager = new SaveManager();
            manager.SaveIntoJson(scoreText.text, timeText.text);
            loadFinishScene();
        }
    }

    void loadFinishScene()
    {
        SceneManager.LoadScene("FinishScene");
    }
}
